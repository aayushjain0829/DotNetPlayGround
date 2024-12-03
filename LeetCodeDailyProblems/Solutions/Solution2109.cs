
using System.Text;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution2109 : Solution<string, CustomEnumerable<int>, string>
{
    #region Algos
    private string AddSpaces(string s, int[] spaces)
    {
        StringBuilder sb = new StringBuilder();
        int startIndex = 0;

        foreach (int i in spaces)
        {
            sb.Append(s.Substring(startIndex, i - startIndex));
            sb.Append(' ');
            startIndex = i;
        }

        return sb.Append(s.Substring(startIndex, s.Length - startIndex)).ToString();
    }
    #endregion

    public override string Execute(string input1, CustomEnumerable<int> input2)
    {
        return AddSpaces(input1, input2.ToArray());
    }

    public override IEnumerable<(string, CustomEnumerable<int>)> TestCases()
    {
        return [
            ("LeetcodeHelpsMeLearn", new([8,13,15])),
            ("icodeinpython", new([1,5,7,9])),
            ("spacing", new([0,1,2,3,4,5,6]))
            ];
    }
}
