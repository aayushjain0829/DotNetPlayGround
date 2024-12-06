
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2337 : Solution<string, string, bool>
{
    #region Algos
    private bool CanChange(string start, string target)
    {
        int n = start.Length;
        char[] s = start.ToCharArray(), t = target.ToCharArray();

        for (int i = 0; i < n; i++)
        {
            if (s[i] == t[i]) continue;
            if (s[i] == 'L') return false;
            if (s[i] == '_')
            {
                if (t[i] == 'R') return false;

                int j = i+1;
                while (j < n && s[j] == '_') j++;
                if (j == n || s[j] == 'R') return false;
                s[j] = '_';
            }
            else
            {
                int j = i;
                while (j < n && t[j] == '_') j++;
                if (j == n || t[j] == 'L') return false;
                t[j] = '_';
            }
        }

        return true;
    }
    #endregion
    public override bool Execute(string input1, string input2)
    {
        return CanChange(input1, input2);
    }

    public override IEnumerable<(string, string)> TestCases()
    {
        return [
            ("_L__R__R_", "L______RR"),
            ("R_L_", "__LR"),
            ("_R", "R_")
            ];
    }
}
