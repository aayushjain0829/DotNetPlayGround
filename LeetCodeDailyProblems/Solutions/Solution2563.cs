
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2563 : Solution<CustomEnumerable<int>, int, int, long>
{
    #region Algos
    long CountFairPairs(int[] nums, int lower, int upper)
    {
        long ans = 0;
        Array.Sort(nums);

        for (int ci = nums.Length - 1, ui = 0, li = 0; ci >= 0; ci--)
        {
            ui = Math.Min(ui, ci);
            li = Math.Min(li, ui);
            while (ui < ci && nums[ci] + nums[ui] <= upper) ui++;
            while (li < ui && nums[ci] + nums[li] < lower) li++;
            ans += ui - li;
        }

        return ans;
    }
    #endregion

    public override long Execute(CustomEnumerable<int> input1, int input2, int input3)
    {
        return CountFairPairs(input1.ToArray(), input2, input3);
    }

    public override IEnumerable<(CustomEnumerable<int>, int, int)> TestCases()
    {
        return [
            (new([0,1,7,4,4,5]), 3, 6),
            (new([1,7,9,2,5]), 11, 11),
            (new([-1,0]),1,1),
            (new([0,0,0,0,0,0]),0,0)
            ];
    }
}
