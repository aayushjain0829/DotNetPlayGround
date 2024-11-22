
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2461 : Solution<CustomEnumerable<int>, int, long>
{
    #region Algos
    private long MaximumSubarraySum(int[] nums, int k)
    {
        int countDuplicates = 0;
        long currSum = 0, maxSum = 0;
        var freq = new Dictionary<int, int>();

        for (int i = 0; i < k-1; i++)
        {
            currSum += nums[i];

            if (freq.ContainsKey(nums[i])) freq[nums[i]]++;
            else freq.Add(nums[i], 1);

            if (freq[nums[i]] == 2) countDuplicates++;
        }

        for (int i = k - 1; i < nums.Length; i++)
        {
            currSum += nums[i];

            if (freq.ContainsKey(nums[i])) freq[nums[i]]++;
            else freq.Add(nums[i], 1);

            if (freq[nums[i]] == 2) countDuplicates++;
            if (countDuplicates == 0) maxSum = Math.Max(maxSum, currSum);

            currSum -= nums[i - k + 1];
            freq[nums[i-k+1]]--;
            if (freq[nums[i-k+1]] == 1) countDuplicates--;
        }

        return maxSum;
    }
    #endregion

    public override long Execute(CustomEnumerable<int> input1, int input2)
    {
        return MaximumSubarraySum(input1.ToArray(), input2);
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return [
            (new([1,5,4,2,9,9,9]), 3),
            (new([4,4,4]), 3)
            ];
    }
}
