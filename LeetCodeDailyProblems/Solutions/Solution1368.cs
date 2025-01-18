
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1368 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int MinCost(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length, currCost = 0;
        var vis = new bool[m, n];
        var q = new Queue<(int, int)>();
        int[][] adj = [[0, 0], [0, 1], [0,-1], [1,0], [-1,0]];

        q.Enqueue((0, 0));

        while (q.Count > 0)
        {
            var candidates = new Queue<(int, int)>();
            while (q.Count > 0)
            {
                var (a, b) = q.Dequeue();
                if (vis[a, b]) continue;

                vis[a, b] = true;
                if (a == m - 1 && b == n - 1) return currCost;

                for (int i=1; i<5; i++)
                {
                    int x = a + adj[i][0], y = b + adj[i][1];
                    if (x >= 0 && x < m && y >=0  && y < n && !vis[x, y])
                    {
                        if (grid[a][b] == i) q.Enqueue((x, y));
                        else candidates.Enqueue((x, y));
                    }
                }    
            }

            currCost++;
            q = candidates;
        }

        return -1;
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return MinCost(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([ new([1,1,1,1]), new([2,2,2,2]), new([1,1,1,1]), new([2,2,2,2])]),
            new([ new([1,1,3]), new([3,2,2]), new([1,1,4])]),
            new([ new([1,2]), new([4,3])])
            ];
    }
}
