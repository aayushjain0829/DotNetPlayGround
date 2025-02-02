
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1752 : Solution<CustomEnumerable<int>, bool>
{
    #region Algos
    private bool Check(int[] nums)
    {
        int flagIdx = -1, n = nums.Length;
        
        for (int i = 1; i < n; i++)
        {
            if (nums[i] < nums[i-1])
            {
                flagIdx = i;
                break;
            }
        }

        if (flagIdx < 0) return true;

        for (int i = 1; i < n; i++)
        {
            int j = (i + flagIdx) % n;
            int k = (i + flagIdx - 1) % n;
            if (nums[j] < nums[k])
            {
                return false;
            }
        }

        return true;
    }
    #endregion

    public override bool Execute(CustomEnumerable<int> input)
    {
        return Check(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([3,4,5,1,2]),
            new([2,1,3,4]),
            new([1,2,3]),
            new([6,10,6])
            ];
    }
}
