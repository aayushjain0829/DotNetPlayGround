
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2138 : Solution<string, int, char, CustomEnumerable<string>>
{
    #region Algos
    private string[] DivideString(string s, int k, char fill)
    {
        var ans = new List<string>();
        for (int i = 0; i < s.Length; i+=k)
        {
            string temp;
            if (i + k < s.Length) temp = s.Substring(i, k);
            else temp = s.Substring(i).PadRight(k, fill);
            ans.Add(temp);
        }

        return ans.ToArray();
    }
    #endregion

    public override CustomEnumerable<string> Execute(string input1, int input2, char input3)
    {
        return new CustomEnumerable<string> (DivideString(input1, input2, input3));
    }

    public override IEnumerable<(string, int, char)> TestCases()
    {
        return [
            ("abcdefghi", 3, 'x'),
            ("abcdefghij", 3, 'x')
            ];
    }
}
