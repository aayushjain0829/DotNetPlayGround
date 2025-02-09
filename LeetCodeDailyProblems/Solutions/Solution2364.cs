
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2364 : Solution<CustomEnumerable<int>, long>
{
    #region Algos
    private long CountBadPairs(int[] nums)
    {
        long ans = 0;
        var freq = new Dictionary<long, long>();

        for (int i = 0; i < nums.Length; i++)
        {
            long key = nums[i] - i, val = freq.GetValueOrDefault(key);
            ans += i - val;
            freq[key] = val + 1;
        }

        return ans;
    }
    #endregion

    public override long Execute(CustomEnumerable<int> input)
    {
        return CountBadPairs(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([4,1,3,3]),
            new([1,2,3,4,5])
            ];
    }
}
