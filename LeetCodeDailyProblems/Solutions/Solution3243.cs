
namespace LeetCodeDailyProblems.Solutions;

internal class Solution3243 : Solution<int, CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<int>>
{
    #region Algos
    private int[] ShortestDistanceAfterQueries(int n, int[][] queries)
    {
        int m = queries.Length;
        int[] ans = new int[m];
        int[] dist = new int[n];
        List<int>[] nextCity = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            nextCity[i] = [i + 1];
            dist[i] = n-1-i;
        }

        for (int i = 0; i < m; i++)
        {
            nextCity[queries[i][0]].Add(queries[i][1]);
            for (int j = queries[i][0]; j >= 0; j--)
            {
                foreach (var k in nextCity[j])
                {
                    dist[j] = Math.Min(dist[j], dist[k] + 1);
                }
            }

            ans[i] = dist[0];
        }

        return ans;
    }
    #endregion

    public override CustomEnumerable<int> Execute(int input1, CustomEnumerable<CustomEnumerable<int>> input2)
    {
        return new(ShortestDistanceAfterQueries(input1, input2.Select(x => x.ToArray()).ToArray()));
    }

    public override IEnumerable<(int, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (5, new([new([2,4]), new([0,2]), new([0,4])])),
            (4, new([new([0,3]), new([0,2])])),
            (13, new([new([2,4]), new([2,6]), new([5,12])]))
            ];
    }
}
