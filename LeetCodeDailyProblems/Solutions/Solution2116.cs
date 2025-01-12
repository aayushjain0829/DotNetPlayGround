
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2116 : Solution<string, string, bool>
{
    #region Algos
    private bool CanBeValid(string s, string locked)
    {
        int n = s.Length, forward = 0, backward = 0;
        if (n % 2 == 1) return false;

        for (int i = 0; i < n; i++)
        {
            if (s[i] == '(' || locked[i] == '0') forward++;
            else forward--;

            if (s[n-1-i] == ')' || locked[n-1-i] == '0') backward++;
            else backward--;

            if (forward < 0 || backward < 0) return false;
        }

        return true;
    }
    #endregion

    public override bool Execute(string input1, string input2)
    {
        return CanBeValid(input1, input2);
    }

    public override IEnumerable<(string, string)> TestCases()
    {
        return [
            ("))()))", "010100"),
            ("()()", "0000"),
            (")", "0")
            ];
    }
}
