
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1760 : Solution<CustomEnumerable<int>, int, int>
{
    #region Algos
    private int MinimumSize(int[] nums, int maxOperations)
    {
        int l = 1, r = nums.Max();
        while (l < r)
        {
            int mid = l + (r - l) / 2;
            int count = nums.Sum(x => (x - 1) / mid);
            if (count > maxOperations) l = mid + 1;
            else r = mid;
        }

        return r;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input1, int input2)
    {
        return MinimumSize(input1.ToArray(), input2);
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return [
            //(new([9]), 2),
            //(new([2,4,8,2]), 4),
            //(new([5,9]), 2),
            (new([431,922,158,60,192,14,788,146,788,775,772,792,68,143,376,375,877,516,595,82,56,704,160,403,713,504,67,332,26]), 80)];
    }
}
