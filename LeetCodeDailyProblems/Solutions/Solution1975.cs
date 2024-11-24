
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1975 : Solution<CustomEnumerable<CustomEnumerable<int>>, long>
{
    #region Algos
    private long MaxMatrixSum(int[][] matrix)
    {
        int mn = int.MaxValue, negativeParity = 0;
        long sum = 0;

        foreach (var row in matrix)
        {
            foreach (var col in row)
            {
                negativeParity ^= (col < 0) ? 1 : 0;
                mn = Math.Min(mn, Math.Abs(col));
                sum += Math.Abs(col); 
            }
        }

        return sum + (negativeParity * -2 * mn);
    }
    #endregion

    public override long Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return MaxMatrixSum(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([1,-1]), new([-1,1])]),
            new([new([1,2,3]), new([-1,-2,-3]), new([1,2,3])])
            ];
    }
}
