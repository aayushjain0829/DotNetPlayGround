
namespace LeetCodeDailyProblems.Solutions;

internal class Solution3356 : Solution<CustomEnumerable<int>, CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int MinZeroArray(int[] nums, int[][] queries)
    {
        int l = 0, r = queries.Length + 1, n = nums.Length;

        while (l < r)
        {
            int k = l + (r - l) / 2;

            int[] updates = new int[n + 1];
            for (int i = 0; i < k; i++)
            {
                updates[queries[i][0]] += queries[i][2];
                updates[queries[i][1] + 1] -= queries[i][2];
            }

            int curr = 0;
            for (int i = 0; i < n; i++)
            {
                curr += updates[i];
                if (curr < nums[i])
                {
                    curr = -1;
                    break;
                }
            }

            if (curr == -1) l = k + 1;
            else r = k;
        }

        return (r == queries.Length + 1) ? -1 : r;
    }

    private int MinZeroArrayLineSweep(int[] nums, int[][] queries)
    {
        int n = nums.Length, ans = 0, curr = 0;
        int[] diff = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            curr += diff[i];
            while (curr < nums[i] && ans < queries.Length)
            {
                if (queries[ans][0] > i || queries[ans][1] >= i)
                {
                    diff[queries[ans][0]] += queries[ans][2];
                    diff[queries[ans][1] + 1] -= queries[ans][2];

                    if (queries[ans][0] <= i && queries[ans][1] >= i) curr += queries[ans][2];
                }
                ans++;
            }

            if (curr < nums[i]) return -1;
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input1, CustomEnumerable<CustomEnumerable<int>> input2)
    {
        return MinZeroArrayLineSweep(input1.ToArray(), input2.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<(CustomEnumerable<int>, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (new([2,0,2]), new([new([0,2,1]), new([0,2,1]), new([1,1,3])])),
            (new([4,3,2,1]), new([new([1,3,2]), new([0,2,1])]))
            ];
    }
}
