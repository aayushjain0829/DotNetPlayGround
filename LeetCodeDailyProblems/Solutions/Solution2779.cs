

namespace LeetCodeDailyProblems.Solutions;

internal class Solution2779 : Solution<CustomEnumerable<int>, int, int>
{
    #region Algos
    private int MaximumBeauty(int[] nums, int k)
    {
        Array.Sort(nums);

        int end = 0, ans = 1, n = nums.Length;
        for (int i = 0; i < n && end < n; i++)
        {
            while (end < n && nums[end] - 2*k <= nums[i]) end++;
            ans = Math.Max(ans, end - i);
        }

        return ans;
    }

    private int MaximumBeautyHash(int[] nums, int k)
    {
        int mx = nums.Max();
        int[] freq = new int[mx+1];
        foreach (var num in nums) freq[num]++;

        int ans = 0, curr = 0, sz = Math.Min(mx, 2*k);
        for (int i = 0; i < sz; i++) curr += freq[i];

        for (int i = sz; i < mx + 1; i++)
        {
            curr += freq[i];
            ans = Math.Max(ans, curr);
            curr -= freq[i-sz];
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input1, int input2)
    {
        return MaximumBeautyHash(input1.ToArray(), input2);
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return [
            (new([4,6,1,2]), 2),
            (new([1,1,1,1]), 10),
            (new([1,2,3,4]), 0),
            (new([1,1,1,1]), 0),
            ];
    }
}
