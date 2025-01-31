
namespace LeetCodeDailyProblems.Solutions;

internal class Solution827 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int LargestIsland(int[][] grid)
    {
        int n = grid.Length, ans = 0;
        var vis = new int[n, n];
        int[][] dir = [[0,1], [0,-1], [1,0], [-1,0]];

        void bfs(int a, int b)
        {
            int count = 1;
            var q = new Queue<(int a, int b)>();
            var hs0 = new HashSet<(int a, int b)>();

            q.Enqueue((a, b));
            vis[a, b] = 1;

            while (q.Count > 0)
            {
                var (x, y) = q.Dequeue();
                foreach (var d in dir)
                {
                    int h = x + d[0], k = y + d[1];
                    if (h >= 0 && h < n && k >= 0 && k < n)
                    {
                        if (grid[h][k] == 1 && vis[h, k] == 0)
                        {
                            vis[h, k] = 1;
                            count++;
                            q.Enqueue((h, k));
                        }
                        else if (grid[h][k] == 0) hs0.Add((h, k));
                    }
                }
            }

            if (hs0.Count == 0) ans = count;
            else
            {
                foreach (var h in hs0)
                {
                    vis[h.a, h.b] += count;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1 && vis[i, j] == 0)
                {
                    bfs(i, j);
                }
            }
        }

        if (ans != 0) return ans;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                ans = Math.Max(ans, vis[i, j]);
            }
        }

        return ans + 1;
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return LargestIsland(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([1,0]), new([0,1])]),
            new([new([1,1]), new([1,0])]),
            new([new([1,1]), new([1,1])])
            ];
    }
}
