
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1769 : Solution<string, CustomEnumerable<int>>
{
    #region Algos
    private int[] MinOperations(string boxes)
    {
        int Lball = 0, Lcurr = 0, Rball = 0, Rcurr = 0, n = boxes.Length;
        var ans = new int[n];

        for (int i = 0; i < n; i++)
        {
            Lcurr += Lball;
            ans[i] += Lcurr;
            Lball += boxes[i] - '0';

            Rcurr += Rball;
            ans[n-1-i] += Rcurr;
            Rball += boxes[n - 1 - i] - '0';
        }

        return ans;
    }
    #endregion

    public override CustomEnumerable<int> Execute(string input)
    {
        return new(MinOperations(input));
    }

    public override IEnumerable<string> TestCases()
    {
        return [
            "110",
            "001011"
            ];
    }
}
