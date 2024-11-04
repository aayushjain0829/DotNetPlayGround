
using System.Text;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution3163 : Solution<string, string>
{
    #region Algos
    private string CompressedString(string word)
    {
        char curr = word[0];
        int count = 1;
        var comp = new StringBuilder();

        for (int i = 1; i < word.Length; i++)
        {
            if(curr == word[i] && count < 9) count++;
            else
            {
                comp.Append(count).Append(curr);
                curr = word[i];
                count = 1;
            }
        }

        return comp.Append(count).Append(curr).ToString();
    }
    #endregion

    public override string Execute(string input)
    {
        return CompressedString(input);
    }

    public override IEnumerable<string> TestCases()
    {
        return [
            "abcde",
            "aaaaaaaaaaaaaabb"
            ];
    }
}
