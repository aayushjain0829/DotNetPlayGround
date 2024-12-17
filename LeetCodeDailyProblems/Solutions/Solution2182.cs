
using System.Text;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution2182 : Solution<string, int, string>
{
    #region Algos
    private string RepeatLimitedString(string s, int repeatLimit)
    {
        int[] freq = new int[26];
        foreach (char c in s) freq[c - 'a']++;

        int curr = 25;
        StringBuilder sb = new StringBuilder();

        while (true)
        {
            while (curr >= 0 && freq[curr] == 0) curr--;
            if (curr == -1) break;

            int val = 0;
            val = Math.Min(freq[curr], repeatLimit);
            sb.Append((char)(curr + 'a'), val);
            freq[curr] -= val;

            if (freq[curr] > 0)
            {
                int next = curr - 1;
                while (next >= 0 && freq[next] == 0) next--;
                if (next == -1) break;
                sb.Append((char)(next + 'a'));
                freq[next]--;
            }
        }

        return sb.ToString();
    }
    #endregion

    public override string Execute(string input1, int input2)
    {
        return RepeatLimitedString(input1, input2);
    }

    public override IEnumerable<(string, int)> TestCases()
    {
        return [
            ("cczazcc", 3),
            ("aababab", 2)
            ];
    }
}
