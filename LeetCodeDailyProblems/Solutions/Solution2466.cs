
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2466 : Solution<int, int, int, int, int>
{
    #region Algos
    private int CountGoodStrings(int low, int high, int zero, int one)
    {
        int mod = (int)1e9 + 7, sum = 0;
        var dp = new int[high + 1];
        dp[zero]++;
        dp[one]++;

        for (int i = 1; i <= high; i++)
        {
            if (i - zero > 0) dp[i] = (dp[i] + dp[i - zero]) % mod;
            if (i - one > 0) dp[i] = (dp[i] + dp[i - one]) % mod;
            if (i >= low) sum = (sum + dp[i]) % mod;
        }

        return sum;
    }
    #endregion

    public override int Execute(int input1, int input2, int input3, int input4)
    {
        return CountGoodStrings(input1, input2, input3, input4);
    }

    public override IEnumerable<(int, int, int, int)> TestCases()
    {
        return [
            (3,3,1,1),
            (2,3,1,2)
            ];
    }
}
