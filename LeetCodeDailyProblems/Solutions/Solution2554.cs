﻿
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2554 : Solution<CustomEnumerable<int>, int, int, int>
{
    #region Algos
    private int MaxCount(int[] banned, int n, int maxSum)
    {
        int count = 0, sum = 0, j = 0;
        Array.Sort(banned);

        for (int i = 1; i<=n; i++)
        {
            if(j < banned.Length && i == banned[j])
            {
                while (++j < banned.Length && banned[j] == banned[j - 1]) ;
                continue;
            }

            sum += i;
            if (sum > maxSum) break;
            count++;
        }

        return count;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input1, int input2, int input3)
    {
        return MaxCount(input1.ToArray(), input2, input3);
    }

    public override IEnumerable<(CustomEnumerable<int>, int, int)> TestCases()
    {
        return [
            (new([1,6,5]), 5, 6),
            (new([1,2,3,4,5,6,7]), 8, 1),
            (new([11]), 7, 50),
            (new([87,193,85,55,14,69,26,133,171,180,4,8,29,121,182,78,157,53,26,7,117,138,57,167,8,103,32,110,15,190,139,16,49,138,68,69,92,89,140,149,107,104,2,135,193,87,21,194,192,9,161,188,73,84,83,31,86,33,138,63,127,73,114,32,66,64,19,175,108,80,176,52,124,94,33,55,130,147,39,76,22,112,113,136,100,134,155,40,170,144,37,43,151,137,82,127,73]), 1079, 87)
            ];
    }
}