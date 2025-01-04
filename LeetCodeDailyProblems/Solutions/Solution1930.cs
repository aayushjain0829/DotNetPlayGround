
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1930 : Solution<string, int>
{
    #region Algos
    private int CountPalindromicSubsequence(string s)
    {
        int n = s.Length, ans = 0;
        var range = new (int start, int end)[26];
        var curr = new int[26];
        var dp = new List<int[]>();

        for (int i = 0; i < 26; i++) range[i] = (-1, -1);
        for (int i = 0; i < n; i++)
        {
            int key = s[i] - 'a';
            if (range[key].start == -1) range[key] = (i, i);
            else range[key].end = i;

            curr[key]++;
            var cpy = new int[26];
            curr.CopyTo(cpy, 0);
            dp.Add(cpy);
        }

        for (int i = 0; i < 26; i++)
            if (range[i].end != range[i].start)
                for (int j = 0; j < 26; j++)
                    ans += ((dp[range[i].end - 1][j] - dp[range[i].start][j] > 0) ? 1 : 0);

        return ans;
    }
    #endregion

    public override int Execute(string input)
    {
        return CountPalindromicSubsequence(input);
    }

    public override IEnumerable<string> TestCases()
    {
        return [
            "aabca",
            "adc",
            "bbcbaba"
            ];
    }
}
