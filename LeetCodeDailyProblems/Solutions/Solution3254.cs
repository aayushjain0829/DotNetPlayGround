
namespace LeetCodeDailyProblems.Solutions;

internal class Solution3254 : Solution<CustomEnumerable<int>, int, CustomEnumerable<int>>
{
    #region Algos
    private int[] ResultsArray(int[] nums, int k)
    {
        int n = nums.Length;
        int[] ans = new int[n-k+1];

        for (int i = 0; i < n - k + 1; i++)
        {
            int val = nums[i + k - 1];
            for (int j = i+1; j < i + k; j++)
            {
                if (nums[j] != nums[j-1] + 1)
                {
                    val = -1;
                    break;
                }
            }

            ans[i] = val;
        }

        return ans;
    }
    #endregion

    public override CustomEnumerable<int> Execute(CustomEnumerable<int> input1, int input2)
    {
        return new (ResultsArray(input1.ToArray(), input2));
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return [
            (new([1,2,3,4,3,2,5]), 3),
            (new([2,2,2,2,2]), 4),
            (new([3,2,3,2,3,2]), 2)
            ];
    }
}
