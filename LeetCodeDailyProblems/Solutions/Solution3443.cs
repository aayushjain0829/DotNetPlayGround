
namespace LeetCodeDailyProblems.Solutions;

internal class Solution3443 : Solution<string, int, int>
{
    #region Algos
    private int MaxDistance(string s, int k)
    {
        int v = 0, h = 0, ans = 0;
        for (int i=0; i<s.Length; i++)
        {
            switch (s[i])
            {
                case 'N':
                    v++;
                    break;
                case 'S':
                    v--;
                    break;
                case 'E':
                    h++;
                    break;
                case 'W':
                    h--;
                    break;


            }
            ans = Math.Max(ans, Math.Min(Math.Abs(v) + Math.Abs(h) + 2 * k, i + 1));
        }

        return ans;
    }
    #endregion

    public override int Execute(string input1, int input2)
    {
        return MaxDistance(input1, input2);
    }

    public override IEnumerable<(string, int)> TestCases()
    {
        return [
            ("NWSE", 1),
            ("NSWWEW", 3)
            ];
    }
}
