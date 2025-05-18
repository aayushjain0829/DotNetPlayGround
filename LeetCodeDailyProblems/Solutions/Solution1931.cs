
using System.Text;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution1931 : Solution<int, int, int>
{
    #region Algos

    private int ColorTheGrid(int m, int n)
    {
        int mn = 0;
        int sz = (int)Math.Pow(3, m);
        int mod = 1000000007;
        int result = 0;
        bool[] validMask = new bool[sz];
        bool[,] validConvert = new bool[sz, sz];
        int[] prev = new int[sz];

        for (int i=mn; i < sz; i++)
        {
            int i3 = i / 3;
            int i3Prev = i % 3;
            validMask[i] = true;
            for (int j=1; j<m; j++)
            {
                if ((i3 % 3) == i3Prev)
                {
                    validMask[i] = false;
                    break;
                }
                i3Prev = i3 % 3;
                i3 /= 3;
            }
        }

        for (int i = mn; i < sz; i++)
        {
            for (int j = mn; j < sz; j++)
            {
                if (i == j || !validMask[i] || !validMask[j]) continue;
                validConvert[i, j] = true;

                int i3 = i;
                int j3 = j;
                for (int k = 0; k < m; k++)
                {
                    if ((i3 % 3) == (j3 % 3))
                    {
                        validConvert[i, j] = false;
                        break;
                    }
                    i3 /= 3;
                    j3 /= 3;
                }
            }
        }

        for (int i = mn; i < sz; i++) prev[i] = (validMask[i] ? 1 : 0);

        for (int i = 1; i < n; i++)
        {
            int[] curr = new int[sz];
            for (int j = mn; j < sz; j++)
            {
                if (!validMask[j]) continue;
                for (int k = mn; k < sz; k++) if (validConvert[k, j]) curr[j] = (curr[j] + prev[k]) % mod;
            }
            prev = curr;
        }

        foreach (var i in prev) result = (result + i) % mod;

        return result;
    }
    #endregion

    public override int Execute(int input1, int input2)
    {
        return ColorTheGrid(input1, input2);
    }

    public override IEnumerable<(int, int)> TestCases()
    {
        return [
            (1, 1),
            (1, 2),
            (5, 5)
            ];
    }
}
