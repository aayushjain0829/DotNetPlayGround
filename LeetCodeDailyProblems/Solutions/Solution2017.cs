
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2017 : Solution<CustomEnumerable<CustomEnumerable<int>>, long>
{
    #region Algos
    private long GridGame(int[][] grid)
    {
        int n = grid[0].Length;
        long firstRowSum = 0, secondRowSum = 0, ans = long.MaxValue;

        for (int i = 0; i < n; i++) firstRowSum += grid[0][i];
        for (int i = 0; i < n; i++)
        {
            firstRowSum -= grid[0][i];
            ans = Math.Min(ans, Math.Max(firstRowSum, secondRowSum));
            secondRowSum += grid[1][i];
        }

        return ans;
    }
    #endregion

    public override long Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return GridGame(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([ new([2, 5, 4]), new([1, 5, 1])]),
            new([ new([3, 3, 1]), new([8, 5, 2])]),
            new([ new([1, 3, 1, 15]), new([1, 3, 3, 1])])
            ];
    }
}
