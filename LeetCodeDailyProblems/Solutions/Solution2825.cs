
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2825 : Solution<string, string, bool>
{
    #region Algos
    private bool CanMakeSubsequence(string str1, string str2)
    {
        int n = str2.Length, idx = 0;
        foreach (var ch in str1)
        {
            int c1 = ch - 'a', c2 = str2[idx] - 'a';
            if (c1 == c2 || (c1 + 1) % 26 == c2) idx++;
            if (idx == n) return true;
        }

        return false;
    }
    #endregion

    public override bool Execute(string input1, string input2)
    {
        return CanMakeSubsequence(input1, input2);
    }

    public override IEnumerable<(string, string)> TestCases()
    {
        return [
            ("abc", "ad"),
            ("zc", "ad"),
            ("ab", "d")
            ];
    }
}
