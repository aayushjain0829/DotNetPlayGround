
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2401 : Solution<CustomEnumerable<int>, int>
{
    #region Algos
    private int LongestNiceSubarray(int[] nums)
    {
        int n = nums.Length, start = 0, ans = 1;
        long xor = nums[0];

        for (int end = 1; end < n; end++)
        {
            while ((nums[end] ^ xor) != nums[end] + xor) xor ^= nums[start++];
            xor ^= nums[end];
            ans = Math.Max(ans, end - start + 1);
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input)
    {
        return LongestNiceSubarray(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([1,3,8,48,10]),
            new([3,1,5,11,13])
            ];
    }
}
