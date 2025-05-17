
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2901 : Solution<CustomEnumerable<string>, CustomEnumerable<int>, CustomEnumerable<string>>
{
    #region Algos
    private IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
    {
        int n = words.Length, mxCount = 1, mxIdx = 0;
        var dp = new (int idx, int count)[n];
        dp[0] = (-1, 1);

        int HammingDistance(int i, int j)
        {
            int dist = 0;
            for (int k = 0; k < words[i].Length; k++)
            {
                if (words[i][k] != words[j][k]) dist++;
            }
            return dist;
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (HammingDistance(i, j) == 1 && groups[i] != groups[j] && dp[j].count + 1 > dp[i].count)
                {
                    dp[i] = (j, dp[j].count + 1);       
                } 
            }
            if (dp[i].count > mxCount)
            {
                mxCount = dp[i].count;
                mxIdx = i;
            }
        }

        var result = new List<string>();
        while (mxIdx != -1)
        {
            result.Add(words[mxIdx]);
            mxIdx = dp[mxIdx].idx;
        }

        result.Reverse();
        return result;
    }
    #endregion

    public override CustomEnumerable<string> Execute(CustomEnumerable<string> input1, CustomEnumerable<int> input2)
    {
        return new(GetWordsInLongestSubsequence(input1.ToArray(), input2.ToArray()));
    }

    public override IEnumerable<(CustomEnumerable<string>, CustomEnumerable<int>)> TestCases()
    {
        return [
            (new(["bab","dab","cab"]), new([1,2,2])),
            (new(["a","b","c","d"]), new([1,2,3,4]))
            ];
    }
}
