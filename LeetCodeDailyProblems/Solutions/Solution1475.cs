
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1475 : Solution<CustomEnumerable<int>, CustomEnumerable<int>>
{
    #region Algos
    private int[] FinalPrices(int[] prices)
    {
        int n = prices.Length;
        for (int i = 0; i < n; i++)
        {
            int j = i + 1;
            while (j < n)
            {
                if (prices[j] <= prices[i])
                    break;
                j++;
            }

            if (j != n)
                prices[i] -= prices[j];
        }

        return prices;
    }
    #endregion

    public override CustomEnumerable<int> Execute(CustomEnumerable<int> input)
    {
        return new(FinalPrices(input.ToArray()));
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([8,4,6,2,3]),
            new([1,2,3,4,5]),
            new([10,1,1,6])
            ];
    }
}
