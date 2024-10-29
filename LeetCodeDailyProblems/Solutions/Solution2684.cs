
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2684 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int MaxMoves(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int[] prev = new int[n];

        for (int j = m - 2; j >= 0; j--)
        {
            int[] curr = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (grid[i][j] < grid[i][j + 1])
                    curr[i] = Math.Max(curr[i], prev[i] + 1);
                if (i > 0 && grid[i][j] < grid[i - 1][j + 1])
                    curr[i] = Math.Max(curr[i], prev[i - 1] + 1);
                if (i < n - 1 && grid[i][j] < grid[i + 1][j + 1])
                    curr[i] = Math.Max(curr[i], prev[i + 1] + 1);
            }
            prev = curr;
        }

        return prev.Max();
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return MaxMoves(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new ([
                new ([2,4,3,5]),
                new ([5,4,9,3]),
                new ([3,4,2,11]),
                new ([10,9,13,15])
                ]),
            new ([
                new ([3,2,4]),
                new ([2,1,9]),
                new ([1,1,7])
                ])
            ];
    }
}
