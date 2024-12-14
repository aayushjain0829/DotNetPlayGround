
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2762 : Solution<CustomEnumerable<int>, long>
{
    #region Algos
    private long ContinuousSubarrays(int[] nums)
    {
        var freq = new Dictionary<int, int>();
        int start = 0, end = 0, n = nums.Length;
        long ans = 0;

        bool IsFreqValid(int val)
        {
            if (freq.Count == 1) return true;
            if (freq.Count > 3) return false;
            
            int[] ks = freq.Keys.ToArray();
            bool res = Math.Abs(ks[0] - ks[1]) <= 2;
            if (freq.Count == 3)
                res = res && (Math.Abs(ks[2] - ks[1]) <= 2) && (Math.Abs(ks[0] - ks[2]) <= 2);

            return res;
        }

        while (end < n)
        {
            int curr = nums[end++];
            freq[curr] = freq.GetValueOrDefault(curr, 0) + 1;
            while (!IsFreqValid(curr))
            {
                freq[nums[start]]--;
                if (freq[nums[start]] == 0) freq.Remove(nums[start]);
                start++;
            }

            ans += end - start;
        }

        return ans;
    }

    private long ContinuousSubarraysSimplified(int[] nums)
    {
        var freq = new Dictionary<int, int>();
        int start = 0, end = 0;
        long ans = 0;

        while (end < nums.Length)
        {
            int curr = nums[end++];
            freq[curr] = freq.GetValueOrDefault(curr, 0) + 1;
            while (freq.Count > 3 || freq.Keys.Max() - freq.Keys.Min() > 2)
            {
                freq[nums[start]]--;
                if (freq[nums[start]] == 0) freq.Remove(nums[start]);
                start++;
            }

            ans += end - start;
        }

        return ans;
    }
    #endregion

    public override long Execute(CustomEnumerable<int> input)
    {
        return ContinuousSubarrays(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([5,4,2,4]),
            new([1,2,3])
            ];
    }
}
