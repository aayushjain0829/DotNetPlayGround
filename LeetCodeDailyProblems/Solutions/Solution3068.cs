
namespace LeetCodeDailyProblems.Solutions;

internal class Solution3068 : Solution<CustomEnumerable<int>, int, CustomEnumerable<CustomEnumerable<int>>, long>
{
    #region Algos
    private long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        long sum = 0, gainCount = 0, minDiff = int.MaxValue;

        foreach (var num in nums)
        {
            int gain = num ^ k;
            gainCount += (gain > num) ? 1 : 0;
            sum += Math.Max(gain, num);
            minDiff = Math.Min(minDiff, Math.Abs(gain - num));
        }

        if (gainCount % 2 == 1) sum -= minDiff;
        return sum;
    }
    #endregion

    public override long Execute(CustomEnumerable<int> input1, int input2, CustomEnumerable<CustomEnumerable<int>> input3)
    {
        return MaximumValueSum(input1.ToArray(), input2, input3.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<(CustomEnumerable<int>, int, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (new([1, 2, 1]), 3, new([new([0, 1]), new([0, 2])])),
            (new([2, 3]), 7, new([new([0, 1])])),
            (new([7,7,7,7,7,7]), 3, new([new([0, 1]), new([0, 2]), new([0, 3]), new([0, 4]), new([0, 5])])),
            (new([24,78,1,97,44]), 6, new([new([0, 2]), new([1, 2]), new([4, 2]), new([3, 4])]))
            ];
    }
}
