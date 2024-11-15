
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2064 : Solution<int, CustomEnumerable<int>, int>
{
    #region Algos
    private int MinimizedMaximum(int n, int[] quantities)
    {
        int l = (int)Math.Ceiling(quantities.Sum(q => (long)q) / (double)n);
        int r = quantities.Max() + 1;
        while (l < r)
        {
            int mid = l + (r - l) / 2;
            int count = quantities.Sum(q => (int)Math.Ceiling(q / (double)mid));

            if (count <= n) r = mid;
            else l = mid + 1;
        }

        return l;
    }
    #endregion

    public override int Execute(int input1, CustomEnumerable<int> input2)
    {
        return MinimizedMaximum(input1, input2.ToArray());
    }

    public override IEnumerable<(int, CustomEnumerable<int>)> TestCases()
    {
        return [
            (6, new([11,6])),
            (7, new([15,10,10])),
            (1, new([100000])),
            (5, new([20,7]))
            ];
    }
}
