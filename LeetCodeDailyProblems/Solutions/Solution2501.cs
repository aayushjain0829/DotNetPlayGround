namespace LeetCodeDailyProblems.Solutions;

internal class Solution2501 : Solution<CustomEnumerable<int>, int>
{
    #region Algos
    private int LongestSquareStreak(int[] nums)
    {
        int ans = 1;
        var dict = new Dictionary<long, int>();
        Array.Sort(nums, (a, b) => b - a);

        foreach (long num in nums)
        {
            int val = 1 + dict.GetValueOrDefault(num * num);
            dict[num] = val;
            ans = Math.Max(ans, val);
        }

        return ans < 2 ? -1 : ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input)
    {
        return LongestSquareStreak(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new ([4,3,6,16,8,2]),
            new ([2,3,5,6,7])
            ];
    }
}
