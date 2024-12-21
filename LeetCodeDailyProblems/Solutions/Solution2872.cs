
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2872 : Solution<int, CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<int>, int, int>
{
    #region Algos
    private int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
    {
        if (edges.Length == 0) return 1;

        int ans = 0;
        var adjList = new Dictionary<int, List<int>>();
        foreach (var edge in edges)
        {
            adjList.TryAdd(edge[0], new List<int>());
            adjList.TryAdd(edge[1], new List<int>());
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        long dfs(int src, int parent)
        {
            long sum = values[src];
            foreach (var node in adjList[src])
                if (node != parent)
                    sum += dfs(node, src);

            if (sum % k == 0) ans++;
            return sum;
        }
        dfs(0, -1);

        return ans;
    }
    #endregion

    public override int Execute(int input1, CustomEnumerable<CustomEnumerable<int>> input2, CustomEnumerable<int> input3, int input4)
    {
        return MaxKDivisibleComponents(input1, input2.Select(x => x.ToArray()).ToArray(), input3.ToArray(), input4);
    }

    public override IEnumerable<(int, CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<int>, int)> TestCases()
    {
        return [
            (5, new([new([0,2]), new([1,2]), new([1,3]), new([2,4])]), new([1,8,1,4,4]), 6),
            (7, new([new([0,1]), new([0,2]), new([1,3]), new([1,4]), new([2,5]), new([2,6])]), new([3,0,6,1,5,2,1]), 3)
            ];
    }
}
