
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2275 : Solution<CustomEnumerable<int>, int>
{
    #region Algos
    private int LargestCombination(int[] candidates)
    {
        var counts = new int[32];

        foreach (int candidate in candidates)
        {
            for (int j = 0; j < 32; j++)
            {
                if ((candidate & (1 << j)) != 0)
                {
                    counts[j]++;
                }
            }
        }

        return counts.Max();
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input)
    {
        return LargestCombination(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new ([16,17,71,62,12,24,14]),
            new ([8,8])
            ];
    }
}
