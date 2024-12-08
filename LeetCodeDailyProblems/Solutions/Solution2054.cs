
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2054 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int MaxTwoEvents(int[][] events)
    {
        int ans = 0, n = events.Length;
        int[] mxVals = new int[n];
        Array.Sort(events, (e1, e2) => e1[0] - e2[0]);

        mxVals[n - 1] = events[n - 1][2];
        for (int i=n-2; i>=0; i--) mxVals[i] = Math.Max(events[i][2], mxVals[i + 1]);

        for (int i = 0; i < n; i++)
        {
            int curr = events[i][2], st = events[i][1] + 1;
            int l = i + 1, r = n, idx = -1;
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (events[mid][0] >= st) r = idx = mid;
                else l = mid + 1;
            }

            if (idx != -1) curr += mxVals[idx];
            ans = Math.Max(ans, curr);
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return MaxTwoEvents(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([1,3,2]), new([4,5,2]), new([2,4,3])]),
            new([new([1,3,2]), new([4,5,2]), new([1,5,5])]),
            new([new([1,5,3]), new([1,5,1]), new([6,6,5])]),
            new([new([1,1,1]), new([2,2,2]), new([3,3,3])])
            ];
    }
}
