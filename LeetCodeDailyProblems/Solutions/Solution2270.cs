
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2270 : Solution<CustomEnumerable<int>, int>
{
    #region Algos
    private int WaysToSplitArray(int[] nums)
    {
        long sum = 0, n = nums.Length, curr = 0, ans = 0;
        for (int i = 1; i < n; i++) sum += nums[i];
        for (int i = 0; i < n-1; i++)
        {
            curr += nums[i];
            if (curr >= sum) ans++;
            sum -= nums[i+1];
        }

        return (int)ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input)
    {
        return WaysToSplitArray(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([10,4,-8,7]),
            new([2,3,1,0])
            ];
    }
}
