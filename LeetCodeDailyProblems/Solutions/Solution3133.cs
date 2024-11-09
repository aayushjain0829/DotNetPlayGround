
using System.Text;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution3133 : Solution<int, int, long>
{
    #region Algos
    long MinEnd(int n, int x)
    {
        var strAns = new StringBuilder(Convert.ToString(x, 2).PadLeft(64, '0'));
        var strMask = Convert.ToString(n - 1, 2);
        var idx = strMask.Length - 1;

        for (var i = 63; i >= 0; i--)
        {
            if (idx < 0) break;
            if (strAns[i] == '1') continue;
            strAns[i] = strMask[idx--];
        }

        return Convert.ToInt64(strAns.ToString(), 2);
    }

    long MinEndBitManipulation(int n, int x)
    {
        long ans = x, mask = n - 1;

        for (int i = 0; i < 64 && mask > 0; i++)
        {
            if ((ans & (1L << i)) == 0) 
            {
                ans |= (mask & 1L) << i;
                mask >>= 1;
            }
        }

        return ans;
    }
    #endregion

    public override long Execute(int input1, int input2)
    {
        return MinEndBitManipulation(input1, input2);
    }

    public override IEnumerable<(int, int)> TestCases()
    {
        return [
            (1,4),
            (3,4),
            (2,7)
            ];
    }
}
