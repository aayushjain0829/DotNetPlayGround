
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2290 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int MinimumObstacles(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length, ans = 0;
        var vis = new bool[n, m];
        int[][] dirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];
        Queue<(int, int)> curr = new();

        curr.Enqueue((n - 1, m - 1));
        while (true)
        {
            Queue<(int, int)> blocked = new();
            while (curr.Count > 0)
            {
                (int x, int y) = curr.Dequeue();
                if (x == 0 && y == 0) return ans;

                foreach (var dir in dirs)
                {
                    int h = x + dir[0], k = y + dir[1];
                    if (h >= 0 && h < n && k >= 0 && k < m && !vis[h, k])
                    {
                        vis[h, k] = true;
                        if (grid[h][k] == 1) blocked.Enqueue((h, k));
                        else curr.Enqueue((h, k));
                    }
                }
            }

            curr = blocked;
            ans++;
        }
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return MinimumObstacles(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([0,1,1]), new([1,1,0]), new([1,1,0])]),
            new([new([0,1,0,0,0]), new([0,1,0,1,0]), new([0,0,0,1,0])])
            ];
    }
}
