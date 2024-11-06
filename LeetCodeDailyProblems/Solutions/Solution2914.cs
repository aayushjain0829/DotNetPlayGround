
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2914 : Solution<string, int>
{
    #region Algos
    private int MinChanges(string s)
    {
        int ans = 0, n = s.Length;
        for (int i = 0; i < n; i+=2)
        {
            if (s[i] != s[i + 1]) ans++;
        }

        return ans;
    }
    #endregion

    public override int Execute(string input)
    {
        return MinChanges(input);
    }

    public override IEnumerable<string> TestCases()
    {
        return [
            "1001",
            "10",
            "0000"
            ];
    }
}
