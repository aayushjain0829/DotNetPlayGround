
namespace LeetCodeDailyProblems.Solutions;

internal class Solution3203 : Solution<CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private (int, int) MaximumDistanceNode(List<int>[] adjList, int start)
    {
        int end = 0, dist = -1, n = adjList.Length;
        Queue<int> queue = new Queue<int>();
        bool[] vis = new bool[n];

        queue.Enqueue(start);
        vis[start] = true;

        while (queue.Count > 0)
        {
            int m = queue.Count;
            for (int i = 0; i < m; i++)
            {
                end = queue.Dequeue();
                foreach (int x in adjList[end])
                {
                    if (!vis[x])
                    {
                        vis[x] = true;
                        queue.Enqueue(x);
                    }
                }
            }

            dist++;
        }

        return (end, dist);
    }

    private int MinimumDiameter(int[][] edges)
    {
        int n = edges.Length + 1;
        var adjList = new List<int>[n];

        for (int i=0; i<n; i++) adjList[i] = new List<int>();
        foreach ( var edge in edges )
        {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        (int node, int _) = MaximumDistanceNode(adjList, 0);
        (int _, int dist) = MaximumDistanceNode(adjList, node);

        return dist;
    }

    private int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
    {
        int d1 = MinimumDiameter(edges1), d2 = MinimumDiameter(edges2);
        return Math.Max(((d1 + 1) / 2) + ((d2 + 1) / 2) + 1, Math.Max(d1, d2));
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input1, CustomEnumerable<CustomEnumerable<int>> input2)
    {
        return MinimumDiameterAfterMerge(input1.Select(x => x.ToArray()).ToArray(), input2.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<(CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (new([new([0,1]), new([0,2]), new([0,3])]), new([new([0,1])])),
            (new([new([0,1]), new([0,2]), new([0,3]), new([2,4]), new([2,5]), new([3,6]), new([2,7])]), new([new([0,1]), new([0,2]), new([0,3]), new([2,4]), new([2,5]), new([3,6]), new([2,7])])),
            (new([new([0,1]), new([2,0]), new([3,2]), new([3,6]), new([8,7]), new([4,8]), new([5,4]), new([3,5]), new([3,9])]), new([new([0,1]), new([0,2]), new([0,3])]))
            ];
    }
}
