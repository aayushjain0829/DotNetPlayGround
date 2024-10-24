namespace LeetCodeDailyProblems.Solutions;

internal class Solution1359 : Solution<string, int>
{
    #region Algos
    private int MaxUniqueSplit(string s)
    {
        int n = s.Length, ans = 1;
        for (int i = 1; i < (1<<n); i++)
        {
            int k = (i ^ (i >> 1));
            string str = s[0].ToString();
            HashSet<string> uniqueSplits = new HashSet<string>();
            
            for (int j = 1; j < n; j++)
            {
                if (( k & (1 << (j-1))) == 0 ) str += s[j];
                else
                {
                    uniqueSplits.Add(str);
                    str = s[j].ToString();
                }
            }

            uniqueSplits.Add(str);
            ans = Math.Max(ans, uniqueSplits.Count);
        }

        return ans;
    }
    #endregion

    public override int Execute(string input)
    {
        return MaxUniqueSplit(input);
    }

    public override IEnumerable<string> TestCases()
    {
        return new List<string>()
        {
            "ababccc",
            "aba",
            "aa",
            "mxybgpnxlathkrft",
            "aabb"
        };
    }
}
