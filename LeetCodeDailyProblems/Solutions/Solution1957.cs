
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1957 : Solution<string, string>
{
    #region Algos
    private string MakeFancyString(string s)
    {
        var stack = new List<char>(s.Length);

        foreach (char c in s)
        {
            if (stack.Count < 2 || stack[^1] != c || stack[^2] != c)
            {
                stack.Add(c);
            }
        }
        return string.Concat(stack);
    }
    #endregion

    public override string Execute(string input)
    {
        return MakeFancyString(input);
    }

    public override IEnumerable<string> TestCases()
    {
        return [
            "leeetcode",
            "aaabaaaa",
            "aab"
            ];
    }
}
