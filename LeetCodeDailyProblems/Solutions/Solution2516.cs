
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2516 : Solution<string, int, int>
{
    #region Algos
    private int TakeCharacters(string s, int k)
    {
        int[] count = new int[3];
        foreach (char c in s)
        {
            count[c - 'a']++;
        }

        if (Math.Min(Math.Min(count[0], count[1]), count[2]) < k)
        {
            return -1;
        }

        // Sliding Window
        int res = int.MaxValue;
        int l = 0;
        for (int r = 0; r < s.Length; r++)
        {
            count[s[r] - 'a']--;

            while (Math.Min(Math.Min(count[0], count[1]), count[2]) < k)
            {
                count[s[l] - 'a']++;
                l++;
            }
            res = Math.Min(res, s.Length - (r - l + 1));
        }
        return res;
    }
    #endregion

    public override int Execute(string input1, int input2)
    {
        return TakeCharacters(input1, input2);
    }

    public override IEnumerable<(string, int)> TestCases()
    {
        return [
            ("aabaaaacaabc", 2),
            ("a", 1)
            ];
    }
}
