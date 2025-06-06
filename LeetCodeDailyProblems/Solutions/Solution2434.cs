
using System.Text;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution2434 : Solution<string, string>
{
    #region Algos
    private string RobotWithString(string s)
    {
        int n = s.Length, curr = 0;
        var sb = new StringBuilder();
        var stk = new Stack<char>();
        var lastPos = new int[26];

        for (int i = 0; i < 26; i++) lastPos[i] = -1;
        for (int i = 0; i < n; i++) lastPos[s[i] - 'a'] = i;
        for (int i = 0; i < 26; i++)
        {
            while (stk.Count > 0 && stk.Peek() <= i+'a') sb.Append(stk.Pop());
            for (int j = curr; j <= lastPos[i]; j++)
            {
                if (s[j] == i + 'a') sb.Append(s[j]);
                else stk.Push(s[j]);
            }
            if (curr <= lastPos[i]) curr = lastPos[i] + 1;
        }

        while (stk.Count > 0) sb.Append(stk.Pop());
        return sb.ToString();
    }
    #endregion

    public override string Execute(string input)
    {
        return RobotWithString(input);
    }

    public override IEnumerable<string> TestCases()
    {
        return [
            "zza",
            "bac",
            "bdda",
            "bydizfve",
            "bzeyxf",
            "vzhofnpo",
            "mmuqezwmomeplrtskz"
            ];
    }
}
