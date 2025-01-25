
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1267 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int CountServers(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int[] rowCount = new int[m];
        int[] colCount = new int[n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    rowCount[i]++;
                    colCount[j]++;
                }
            }
        }

        int count = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1 && (rowCount[i] > 1 || colCount[j] > 1))
                {
                    count++;
                }
            }
        }

        return count;
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return CountServers(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([1,0]), new([0,1])]),
            new([new([1,0]), new([1,1])]),
            new([new([1,1,0,0]), new([0,0,1,0]), new([0,0,1,0]), new([0,0,0,1])])
            ];
    }
}
