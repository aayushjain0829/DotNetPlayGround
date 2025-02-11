
using System.Text;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution1910 : Solution<string, string, string>
{
    #region Algos
    private string RemoveOccurrences(string s, string part)
    {
        if (part.Length > s.Length) return s;

        int count = 0;
        int endIdx = part.Length - 1;
        bool[] removed = new bool[s.Length];

        void RemoveIfPartPresent(int endIdx)
        {
            if (endIdx + 1 - count < part.Length) return;
            int idx = endIdx;
            for (int i = part.Length - 1; i >= 0; i--)
            {
                while (removed[idx]) idx -= part.Length;
                if (s[idx--] != part[i]) return;
            }

            for (int i = idx + 1; i <= endIdx; i++)
            {
                while (removed[i]) i += part.Length;
                removed[i] = true;
            }

            count += part.Length;
        }

        for (int i = part.Length - 1; i < s.Length; i++) RemoveIfPartPresent(i);

        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++) if (!removed[i]) sb.Append(s[i]);
        return sb.ToString();
    }
    #endregion

    public override string Execute(string input1, string input2)
    {
        return RemoveOccurrences(input1, input2);
    }

    public override IEnumerable<(string, string)> TestCases()
    {
        return [
            ("daabcbaabcbc", "abc"),
            ("axxxxyyyyb", "xy"),
            ("kpygkivtlqoockpygkivtlqoocssnextkqzjpycbylkaondsskpygkpygkivtlqoocssnextkqzjpkpygkivtlqoocssnextkqzjpycbylkaondsycbylkaondskivtlqoocssnextkqzjpycbylkaondssnextkqzjpycbylkaondshijzgaovndkjiiuwjtcpdpbkrfsi", "kpygkivtlqoocssnextkqzjpycbylkaonds")
            ];
    }
}
