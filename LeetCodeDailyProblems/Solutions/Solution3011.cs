
using System.Numerics;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution3011 : Solution<CustomEnumerable<int>, bool>
{
    #region Algos
    private bool CanSortArray(int[] nums)
    {
        int prevMax = 0, currMin = nums[0], currMax = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (BitOperations.PopCount((uint)nums[i-1]) == BitOperations.PopCount((uint)nums[i]))
            {
                currMax = Math.Max(currMax, nums[i]);
                currMin = Math.Min(currMin, nums[i]);
            }
            else
            {
                if(prevMax > currMin) return false;
                prevMax = currMax;
                currMin = nums[i];
                currMax = nums[i];
            }
        }

        return prevMax <= currMin;
    }
    #endregion

    public override bool Execute(CustomEnumerable<int> input)
    {
        return CanSortArray(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new ([8,4,2,30,15]),
            new ([1,2,3,4,5]),
            new ([3,16,8,4,2])
            ];
    }
}
