
using System;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution2661 : Solution<CustomEnumerable<int>, CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++) dict[arr[i]] = i;

        int ans = int.MaxValue;
        foreach (var row in mat)
        {
            int curr = 0;
            foreach (var col in row) curr = Math.Max(curr, dict[col]);
            ans = Math.Min(ans, curr);
        }

        for (int i = 0; i < mat[0].Length; i++)
        {
            int curr = 0;
            for (int j = 0; j < mat.Length; j++) curr = Math.Max(curr, dict[mat[j][i]]);
            ans = Math.Min(ans, curr);
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input1, CustomEnumerable<CustomEnumerable<int>> input2)
    {
        return FirstCompleteIndex(input1.ToArray(), input2.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<(CustomEnumerable<int>, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (new([1,3,4,2]), new([new([1,4]), new([2,3])])),
            (new([2,8,7,4,1,3,5,6,9]), new([new([3,2,5]), new([1,4,6]), new([8,7,9])]))
            ];
    }
}
