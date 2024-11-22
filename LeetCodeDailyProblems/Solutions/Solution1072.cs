
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1072 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int MaxEqualRowsAfterFlips(int[][] matrix)
    {
        var count = new Dictionary<string, int>();

        foreach (var row in matrix)
        {
            var key = new int[row.Length];
            for (int i = 0; i < row.Length; i++)
            {
                key[i] = row[0] == 1 ? 1 - row[i] : row[i];
            }
            var rowKey = string.Join(",", key);
            count[rowKey] = count.GetValueOrDefault(rowKey, 0) + 1;
        }

        return count.Values.Max();
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return MaxEqualRowsAfterFlips(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([0,1]), new([1,1])]),
            new([new([0,1]), new([1,0])]),
            new([new([0,0,0]), new([0,0,1]), new([1,1,0])])
            ];
    }
}
