
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2658 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int FindMaxFish(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length, ans = 0;
        int[][] dir = [[0, 1], [0,-1], [1, 0], [-1, 0]];

        int dfs(int x, int y)
        {
            int res = grid[x][y];
            grid[x][y] *= -1;

            foreach (var d in dir)
            {
                int a = x + d[0], b = y + d[1];
                if (a >= 0 && a < m && b >= 0 && b < n && grid[a][b] > 0) res += dfs(a, b);
            }

            return res;
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] > 0) ans = Math.Max(ans, dfs(i, j));
            }
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return FindMaxFish(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([0,2,1,0]), new([4,0,0,3]), new([1,0,0,4]), new([0,3,2,0])]),
            new([new([1,0,0,0]), new([0,0,0,0]), new([0,0,0,0]), new([0,0,0,1])]),
            new([new([4,5,5]), new([0,10,0])])
            ];
    }
}
