
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2490 : Solution<string, bool>
{
    #region Algos
    private bool IsCircularSentence(string sentence)
    {
        var words = sentence.Split(' ');

        if (words[^1][^1] != words[0][0]) return false;
        for (int i = words.Length - 1; i>0; i--)
        {
            if (words[i][0] != words[i - 1][^1]) return false;
        }

        return true;
    }
    #endregion

    public override bool Execute(string input)
    {
        return IsCircularSentence(input);
    }

    public override IEnumerable<string> TestCases()
    {
        return [
            "leetcode exercises sound delightful",
            "eetcode",
            "Leetcode is cool"
            ];
    }
}
