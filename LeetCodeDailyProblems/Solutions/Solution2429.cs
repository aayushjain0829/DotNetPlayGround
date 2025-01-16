
using System.Numerics;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution2429 : Solution<int, int, int>
{
    #region Algos
    private int MinimizeXor(int num1, int num2)
    {
        int ans = num1;
        int diff = BitOperations.PopCount((uint)num2) - BitOperations.PopCount((uint)num1);
        
        for (int i = 0; diff < 0 && i < 32; i++)
        {
            if ((num1 & (1 << i)) != 0)
            {
                ans ^= (1 << i);
                diff++;
            }
        }

        for (int i = 0; diff > 0 && i < 32; i++)
        {
            if ((num1 & (1 << i)) == 0)
            {
                ans ^= (1 << i);
                diff--;
            }
        }

        return ans;
    }
    #endregion

    public override int Execute(int input1, int input2)
    {
        return MinimizeXor(input1, input2);
    }

    public override IEnumerable<(int, int)> TestCases()
    {
        return [
            (25, 72),
            (3, 5),
            (1, 12)
            ];
    }
}
