
using System.Text;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution1415 : Solution<int, int, string>
{
    #region Algos
    private string GetHappyString(int n, int k)
    {
        int div = 1 << (n - 1);
        if (k > 3 * div) return "";

        int segment = 0, prev = -1;
        var sb = new StringBuilder();

        while (div > 0)
        {
            segment = (int)Math.Ceiling(((double)k) / div) - 1;
            k -= segment * div;

            if (prev == 0) segment++;
            else if (prev == 1) segment <<= 1;
            prev = segment;

            sb.Append((char)(segment + 'a'));
            div >>= 1;
        }

        return sb.ToString();
    }
    #endregion

    public override string Execute(int input1, int input2)
    {
        return GetHappyString(input1, input2);
    }

    public override IEnumerable<(int, int)> TestCases()
    {
        return [
            (1, 3),
            (1, 4),
            (3, 9)
            ];
    }
}
