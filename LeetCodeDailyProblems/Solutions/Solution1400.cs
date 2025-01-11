
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1400 : Solution<string, int, bool>
{
    #region Algos
    private bool CanConstruct(string s, int k)
    {
        int n = s.Length;
        if (n < k) return false;
        if (k >= 26) return true;

        var freq = new int[26];
        foreach (var ch in s) freq[ch-'a']++;

        int odds = 0;
        foreach (var i in freq) if (i % 2 == 1) odds++;

        if (odds > k) return false;
        return true;
    }
    #endregion

    public override bool Execute(string input1, int input2)
    {
        return CanConstruct(input1, input2);
    }

    public override IEnumerable<(string, int)> TestCases()
    {
        return [
            ("annabelle", 2),
            ("leetcode", 3),
            ("true", 4)
            ];
    }
}
