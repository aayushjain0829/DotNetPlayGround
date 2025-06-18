
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2966 : Solution<CustomEnumerable<int>, int, CustomEnumerable<CustomEnumerable<int>>>
{
    #region Algos
    private int[][] DivideArray(int[] nums, int k)
    {
        int n = nums.Length;
        var ans = new int[n / 3][];
        Array.Sort(nums);

        for (int i=2; i<n; i+=3)
        {
            if (nums[i] - nums[i - 2] > k) return [];
            ans[i / 3] = [nums[i - 2], nums[i - 1], nums[i]];
        }

        return ans;
    }
    #endregion

    public override CustomEnumerable<CustomEnumerable<int>> Execute(CustomEnumerable<int> input1, int input2)
    {
        return new CustomEnumerable<CustomEnumerable<int>>(DivideArray(input1.ToArray(), input2).Select(x => new CustomEnumerable<int>(x)));
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return [
            (new([1,3,4,8,7,9,3,5,1]), 2),
            (new([2,4,2,2,5,2]), 2),
            (new([4,2,9,8,2,12,7,12,10,5,8,5,5,7,9,2,5,11]), 14)
            ];
    }
}
