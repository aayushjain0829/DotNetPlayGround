
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1639 : Solution<CustomEnumerable<string>, string, int>
{
    #region Algos
    private int NumWaysTLE(string[] words, string target)
    {
        int n = words[0].Length, m = words.Length, t = target.Length, mod = (int)1e9+7;
        var dp = new long[n, t];
        for (int i = 0; i < n; i++) for (int j = 0; j < t; j++) dp[i, j] = -1;

        long func(int a, int b)
        {
            if (b == t) return 1;
            if (a == n) return 0;
            if (dp[a, b] != -1) return dp[a, b];

            int count = 0;
            foreach (var word in words) if (word[a].CompareTo(target[b]) == 0) count++;
            
            long res = func(a+1, b);
            if (count != 0) res += (count * func(a + 1, b + 1)) % mod;

            return dp[a, b] = res % mod;
        }

        return (int)func(0,0);
    }

    private int NumWays(string[] words, string target)
    {
        int n = words[0].Length, t = target.Length, mod = (int)1e9 + 7;
        var freq = new int[n, 26];
        var prev = new long[t];

        foreach (var word in words) for (int i = 0; i < n; i++) freq[i, word[i] - 'a']++;
        prev[t - 1] = freq[n - 1, target[t - 1] - 'a'];

        for (int i = n - 2; i >= 0; i--)
        {
            var curr = new long[t];
            curr[t-1] = freq[i, target[t-1] - 'a'] + prev[t-1];
            for (int j = t - 2; j >= 0; j--)
            {
                int c = freq[i, target[j] - 'a'];
                curr[j] = (((prev[j + 1] * c) % mod) + prev[j]) % mod;
            }

            prev = curr;
        }

        return (int)prev[0];
    }
    #endregion

    public override int Execute(CustomEnumerable<string> input1, string input2)
    {
        return NumWays(input1.ToArray(), input2);
    }

    public override IEnumerable<(CustomEnumerable<string>, string)> TestCases()
    {
        return [
            (new(["acca","bbbb","caca"]), "aba"),
            (new(["abba","baab"]), "bab")
            ];
    }
}
