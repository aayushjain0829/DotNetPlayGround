namespace LeetCodeDailyProblems.Solutions;

internal class Solution921 : Solution<string, int>
{
    #region Algos
    public int MinAddToMakeValid(string s)
    {
        int ans = 0;
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (c == ')')
            {
                if (!stack.TryPeek(out char topChar) || topChar != '(') ans++;
                else stack.Pop();
            }
            else stack.Push(c);
        }

        return ans + stack.Count;
    }
    #endregion

    public override int Execute(string input)
    {
        return MinAddToMakeValid(input);
    }

    public override IEnumerable<string> TestCases()
    {
        return new List<string>() {
            "())",
            "((("
        };
    }
}
