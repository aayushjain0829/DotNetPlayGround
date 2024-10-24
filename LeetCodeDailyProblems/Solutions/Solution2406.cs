namespace LeetCodeDailyProblems.Solutions;

internal class Solution2406 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int MinGroups(int[][] intervals)
    {
        Array.Sort(intervals, Comparer<int[]>.Create((x, y) =>
        {
            if (x[0] == y[0]) return x[1] - y[1];
            return x[0] - y[0];
        }));

        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        foreach (var interval in intervals)
        {
            if (pq.Count == 0 || pq.Peek() >= interval[0]) pq.Enqueue(interval[1], interval[1]);
            else pq.DequeueEnqueue(interval[1], interval[1]);
        }

        return pq.Count;
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return MinGroups(input.Select(item => item.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        var testCases = new List<int[][]> {
            new int[][] {[5, 10], [6, 8], [1, 5], [2, 3], [1, 10] },
            new int[][] {[1, 3], [5, 6], [8, 10], [11, 13]}
        };

        return testCases.Select(array =>
            new CustomEnumerable<CustomEnumerable<int>>(
                array.Select(innerArray => new CustomEnumerable<int>(innerArray))
            )
        ).ToList();
    }
}
