
namespace LeetCodeDailyProblems.Solutions;

internal class Solution689 : Solution<CustomEnumerable<int>, int, CustomEnumerable<int>>
{
    #region Algos
    private int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        int n = nums.Length;

        var dp1 = new (int idx, int sum)[n - k + 1];
        int idx = n - 1, sum = 0;
        while (idx > n - k) sum += nums[idx--];

        int curr = idx, mx = sum;
        while (idx >= 2*k)
        {
            sum += nums[idx];
            if (sum >= mx) 
            {
                mx = sum;
                curr = idx;
            }
            dp1[idx] = (curr, mx);
            sum -= nums[idx + k - 1];
            idx--;
        }

        var dp2 = new (int idx1, int idx2, int sum)[n - 2 * k + 1];
        int idx1 = n - k - 1, sum2 = 0;
        while (idx1 > n - 2 * k) sum2 += nums[idx1--];

        int ci1 = idx1, ci2 = idx1 + k, mx2 = sum2;
        while (idx1 >= k)
        {
            sum2 += nums[idx1] + dp1[idx1 + k].sum;
            if (sum2 >= mx2)
            {
                mx2 = sum2;
                ci1 = idx1;
                ci2 = dp1[idx1 + k].idx;
            }
            dp2[idx1] = (ci1, ci2, mx2);
            sum2 = sum2 - (nums[idx1 + k - 1] + dp1[idx1 + k].sum);
            idx1--;
        }

        int i = n - 2*k -1, sum3 = 0;
        while (i > n-3*k) sum3 += nums[i--];

        int cIdx = i, mx3 = sum3;
        while (i >= 0)
        {
            sum3 += nums[i] + dp2[i + k].sum;
            if (sum3 >= mx3)
            {
                mx3 = sum3;
                cIdx = i;
            }
            sum3 = sum3 - (nums[i+k-1] + dp2[i+k].sum);
            i--;
        }

        return [cIdx, dp2[cIdx + k].idx1, dp2[cIdx + k].idx2];
    }
    #endregion

    public override CustomEnumerable<int> Execute(CustomEnumerable<int> input1, int input2)
    {
        return new(MaxSumOfThreeSubarrays(input1.ToArray(), input2));
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return [
            (new([1,2,1,2,6,7,5,1]), 2),
            (new([1,2,1,2,1,2,1,2,1]), 2),
            (new([7,13,20,19,19,2,10,1,1,19]), 3)
            ];
    }
}
