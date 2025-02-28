
using System.Text;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution1092 : Solution<string, string, string>
{
    #region Algos
    private string LongestCommonSubSequence(string s1, string s2)
    {
        int n1 = s1.Length, n2 = s2.Length;
        int[,] dp = new int[n1 + 1, n2 + 1];

        for (int i = 1; i <= n1; i++)
        {
            for (int j = 1; j <= n2; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        StringBuilder lcs = new StringBuilder();

        // Backtrack to construct LCS string
        while (n1 > 0 && n2 > 0)
        {
            if (s1[n1 - 1] == s2[n2 - 1])
            {
                lcs.Append(s1[n1 - 1]);
                n1--; n2--;
            }
            else if (dp[n1 - 1, n2] > dp[n1, n2 - 1])
                n1--;
            else
                n2--;
        }

        return lcs.ToString();
    }

    private string ShortestCommonSupersequence(string str1, string str2)
    {
        string lcs = LongestCommonSubSequence(str1, str2);

        StringBuilder sb = new StringBuilder();
        int i1 = 0, i2 = 0;
        for (int il = lcs.Length - 1; il >= 0; il--, i1++, i2++)
        {
            while (i1 < str1.Length && str1[i1] != lcs[il]) sb.Append(str1[i1++]);
            while (i2 < str2.Length && str2[i2] != lcs[il]) sb.Append(str2[i2++]);
            sb.Append(lcs[il]);
        }
        while (i1 < str1.Length) sb.Append(str1[i1++]);
        while (i2 < str2.Length) sb.Append(str2[i2++]);

        return sb.ToString();
    }
    #endregion

    public override string Execute(string input1, string input2)
    {
        return ShortestCommonSupersequence(input1, input2);
    }

    public override IEnumerable<(string, string)> TestCases()
    {
        return [
            ("abac", "cab"),
            ("aaaaaaaa", "aaaaaaaa")
            ];
    }
}
