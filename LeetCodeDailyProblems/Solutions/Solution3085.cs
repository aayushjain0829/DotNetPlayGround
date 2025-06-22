
namespace LeetCodeDailyProblems.Solutions;

internal class Solution3085 : Solution<string, int, int>
{
    #region Algos
    private int MinimumDeletions(string word, int k)
    {
        var freq = new int[26];
        foreach (char c in word) freq[c - 'a']++;
        Array.Sort(freq);

        int ans = int.MaxValue;
        for (int i = 25; i >= 0; i--)
        {
            if (freq[i] == 0) break;
            int temp = 0;
            for (int j = 0; j < i; j++) temp += freq[j];
            for (int j = i+1; j < 26; j++)
            {
                if (freq[j] <= freq[i] + k) continue;
                temp += freq[j] - freq[i] - k;
            }

            ans = Math.Min(ans, temp);
        }

        return ans;
    }
    #endregion

    public override int Execute(string input1, int input2)
    {
        return MinimumDeletions(input1, input2);
    }

    public override IEnumerable<(string, int)> TestCases()
    {
        return [
            ("aabcaba", 0),
            ("dabdcbdcdcd", 2),
            ("aaabaaa", 2),
            ("ahahnhahhah", 1)
            ];
    }
}
