
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2127 : Solution<CustomEnumerable<int>, int>
{
    #region Algos
    private int MaximumInvitations(int[] favorite)
    {
        int n = favorite.Length;
        var reversedGraph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            reversedGraph[i] = new List<int>();
        }

        for (int person = 0; person < n; ++person)
        {
            reversedGraph[favorite[person]].Add(person);
        }

        // Helper function for BFS
        int Bfs(int startNode, HashSet<int> visitedNodes)
        {
            var q = new Queue<(int currentNode, int currentDistance)>();
            q.Enqueue((startNode, 0));
            int maxDistance = 0;
            while (q.Count > 0)
            {
                var (currentNode, currentDistance) = q.Dequeue();
                foreach (var neighbor in reversedGraph[currentNode])
                {
                    if (visitedNodes.Contains(neighbor)) continue;
                    visitedNodes.Add(neighbor);
                    q.Enqueue((neighbor, currentDistance + 1));
                    maxDistance = Math.Max(maxDistance, currentDistance + 1);
                }
            }
            return maxDistance;
        }

        int longestCycle = 0, twoCycleInvitations = 0;
        var visited = new bool[n];

        // Find all cycles
        for (int person = 0; person < n; ++person)
        {
            if (!visited[person])
            {
                var visitedPersons = new Dictionary<int, int>();
                int current = person;
                int distance = 0;
                while (true)
                {
                    if (visited[current]) break;
                    visited[current] = true;
                    visitedPersons[current] = distance++;
                    int nextPerson = favorite[current];
                    if (visitedPersons.ContainsKey(nextPerson)) // Cycle detected
                    {
                        int cycleLength = distance - visitedPersons[nextPerson];
                        longestCycle = Math.Max(longestCycle, cycleLength);
                        if (cycleLength == 2)
                        {
                            var visitedNodes = new HashSet<int> { current, nextPerson };
                            twoCycleInvitations +=
                                2 + Bfs(nextPerson, visitedNodes) + Bfs(current, visitedNodes);
                        }
                        break;
                    }
                    current = nextPerson;
                }
            }
        }

        return Math.Max(longestCycle, twoCycleInvitations);
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input)
    {
        return MaximumInvitations(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([2,2,1,2]),
            new([1,2,0]),
            new([3,0,1,4,1])
            ];
    }
}
