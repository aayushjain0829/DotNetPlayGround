
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2593 : Solution<CustomEnumerable<int>, long>
{
    #region Algos
    private long FindScore(int[] nums)
    {
        var lst = new List<(int val, int idx)>();
        var vis = new bool[nums.Length];
        long ans = 0;

        for (int i = 0; i < nums.Length; i++)
            lst.Add((nums[i], i));
        lst.Sort((a, b) =>
        {
            if (a.val == b.val) return a.idx.CompareTo(b.idx);
            return a.val.CompareTo(b.val);
        });

        foreach (var (val, idx) in lst)
        {
            if (vis[idx]) continue;

            ans += val;
            vis[idx] = true;
            if (idx - 1 >= 0) vis[idx - 1] = true;
            if (idx + 1 < nums.Length) vis[idx + 1] = true;
        }

        return ans;
    }
    #endregion

    public override long Execute(CustomEnumerable<int> input)
    {
        return FindScore(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([2,1,3,4,5,2]),
            new([2,3,5,1,3,2])
            ];
    }
}
