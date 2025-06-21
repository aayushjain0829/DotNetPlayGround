
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2294 : Solution<CustomEnumerable<int>, int, int>
{
    #region Algos
    private int PartitionArray(int[] nums, int k)
    {
        Array.Sort(nums);
        int ans = 1, curr = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > curr + k)
            {
                curr = nums[i];
                ans++;
            }
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input1, int input2)
    {
        return PartitionArray(input1.ToArray(), input2);
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return [
            (new([3,6,1,2,5]), 2),
            (new([1,2,3]), 1),
            (new([2,2,4,5]), 0)
            ];
    }
}
