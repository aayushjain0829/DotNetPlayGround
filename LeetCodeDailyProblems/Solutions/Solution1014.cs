
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1014 : Solution<CustomEnumerable<int>, int>
{
    #region Algos
    private int MaxScoreSightseeingPair(int[] values)
    {
        int n = values.Length, curr = values[0] - 1, ans = int.MinValue;
        for (int i = 1; i < n; i++)
        {
            ans = Math.Max(ans, values[i] + curr);
            curr = Math.Max(curr, values[i]) - 1;
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input)
    {
        return MaxScoreSightseeingPair(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([8,1,5,2,6]),
            new([1,2])
            ];
    }
}
