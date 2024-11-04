
namespace LeetCodeDailyProblems.Solutions;

internal class Solution796 : Solution<string, string, bool>
{
    #region Algos
    private bool RotateString(string s, string goal)
    {
        return s.Length == goal.Length && (goal + goal).Contains(s);
    }
    #endregion

    public override bool Execute(string input1, string input2)
    {
        return RotateString(input1, input2);
    }

    public override IEnumerable<(string, string)> TestCases()
    {
        return [
            ("abcde", "cdeab"),
            ("abcde", "abced"),
            ("aa", "a")
            ];
    }
}
