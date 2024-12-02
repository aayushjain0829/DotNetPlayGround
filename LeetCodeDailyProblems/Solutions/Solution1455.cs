
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1455 : Solution<string, string, int>
{
    #region Algos
    private int IsPrefixOfWord(string sentence, string searchWord)
    {
        var words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].StartsWith(searchWord))
                return i + 1;
        }

        return -1;
    }
    #endregion

    public override int Execute(string input1, string input2)
    {
        return IsPrefixOfWord(input1, input2);
    }

    public override IEnumerable<(string, string)> TestCases()
    {
        return [
            ("i love eating burger", "burg"),
            ("this problem is an easy problem", "pro"),
            ("i am tired", "you")
        ];
    }
}
