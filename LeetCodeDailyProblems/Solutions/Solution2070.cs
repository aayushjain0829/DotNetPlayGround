
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2070 : Solution<CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<int>, CustomEnumerable<int>>
{
    #region Algos


    private int[] MaximumBeauty(int[][] items, int[] queries)
    {
        int[] ans = new int[queries.Length];

        int mx = 0;
        Array.Sort(items, (a, b) => a[0] - b[0]);
        for(int i = 0; i < items.Length; i++)
            items[i][1] = mx = Math.Max(mx, items[i][1]);

        for (int i = 0; i < queries.Length; i++)
        {
            int l = 0, r = items.Length;
            while (l < r)
            {
                int mid = (r-l) / 2 + l;
                if (items[mid][0] <= queries[i]) l = mid+1;
                else r = mid;
            }

            ans[i] = (r == 0) ? 0 : items[r - 1][1];
        }

        return ans;
    }
    #endregion

    public override CustomEnumerable<int> Execute(CustomEnumerable<CustomEnumerable<int>> input1, CustomEnumerable<int> input2)
    {
        return new (MaximumBeauty(input1.Select(x => x.ToArray()).ToArray(), input2.ToArray()));
    }

    public override IEnumerable<(CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<int>)> TestCases()
    {
        return [
            (new ([new ([1,2]), new ([3,2]), new([2,4]), new([5,6]), new([3,5])]), new([1,2,3,4,5,6])),
            (new ([new ([1,2]), new ([1,2]), new([1,3]), new([1,4])]), new([1])),
            (new ([new([10,1000])]), new([5]))
            ];
    }
}
