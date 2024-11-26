
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2924 : Solution<int, CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int FindChampion(int n, int[][] edges)
    {
        int champion = -1;
        bool[] defeated = new bool[n];

        foreach (var edge in edges) defeated[edge[1]] = true;
        for (int i = 0; i < n; i++)
        {
            if (!defeated[i])
            {
                if (champion != -1) return -1;
                else champion = i;
            }
        }

        return champion;
    }
    #endregion

    public override int Execute(int input1, CustomEnumerable<CustomEnumerable<int>> input2)
    {
        return FindChampion(input1, input2.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<(int, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (3, new([new([0,1]), new([1,2])])),
            (4, new([new([0,2]), new([1,3]), new([1,2])]))
            ];
    }
}
