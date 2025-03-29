
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2503 : Solution<CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<int>, CustomEnumerable<int>>
{
    #region Algos
    private int[] MaxPoints(int[][] grid, int[] queries)
    {
        int k = queries.Length;
        int[] idx = new int[k];
        for (int i = 0; i < k; i++) idx[i] = i;
        Array.Sort(idx, (a, b) => queries[a].CompareTo(queries[b]));

        int m = grid.Length, n = grid[0].Length, currIdx = 0, count = 0;
        var ans = new int[k];
        int[][] dir = [[0, 1], [1, 0], [0, -1], [-1, 0]];
        var pq = new PriorityQueue<(int, int), int>();
        pq.Enqueue((0, 0), grid[0][0]);
        grid[0][0] = -1;

        while (pq.Count > 0)
        {
            pq.TryPeek(out var _, out var priority);
            while (priority >= queries[idx[currIdx]])
            {
                ans[idx[currIdx]] = count;
                currIdx++;
                if (currIdx == k) return ans;
            }

            var cell = pq.Dequeue();
            count++;
            foreach (var d in dir)
            {
                int x = cell.Item1 + d[0], y = cell.Item2 + d[1];
                if (x >= 0 && x < m && y >= 0 && y < n && grid[x][y] != -1)
                {
                    pq.Enqueue((x, y), grid[x][y]);
                    grid[x][y] = -1;
                }
            }
        }

        for (int i = currIdx; i < k; i++) ans[idx[i]] = count;
        return ans;
    }
    #endregion

    public override CustomEnumerable<int> Execute(CustomEnumerable<CustomEnumerable<int>> input1, CustomEnumerable<int> input2)
    {
        return new(MaxPoints(input1.Select(x => x.ToArray()).ToArray(), input2.ToArray()));
    }

    public override IEnumerable<(CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<int>)> TestCases()
    {
        return [
            (new([new([1,2,3]), new([2,5,7]), new([3,5,1])]), new([5,6,2])),
            (new([new([5,2,1]), new([1,1,2])]), new([3])),
            ];
    }
}
