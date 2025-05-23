
namespace LeetCodeDailyProblems.Solutions;

internal class Solution3362 : Solution<CustomEnumerable<int>, CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int MaxRemoval(int[] nums, int[][] queries)
    {
        int q = queries.Length, n = nums.Length, currVal = 0, count = 0;
        var inc = new int[n + 1];
        var pq = new PriorityQueue<int, (int start, int negEnd)>();

        foreach (var query in queries) pq.Enqueue(query[0], (query[0], -query[1]));
        for (int i = 0; i < n; i++)
        {
            currVal += inc[i];
            if (currVal >= nums[i]) continue;

            while (pq.Count > 0 && pq.Peek() < i)
            {
                pq.TryDequeue(out _, out var query);
                if (i <= -query.negEnd) pq.Enqueue(i, (i, query.negEnd));
            }

            while (currVal < nums[i] && pq.Count > 0 && pq.Peek() == i)
            {
                pq.TryDequeue(out _, out var query);
                inc[query.start]++;
                inc[-query.negEnd + 1]--;
                currVal++;
                count++;
            }
            if (currVal < nums[i]) return -1;
        }

        return q - count;
    }

    private int MaxRemovalOptim(int[] nums, int[][] queries)
    {
        int n = nums.Length, m = queries.Length;
        Array.Sort(queries, (a, b) => a[0] - b[0]);
        int[] diff = new int[n + 1];
        PriorityQueue<int, int> pq = new();
        int operations = 0;
        for (int i = 0, j = 0; i < n; i++)
        {
            operations += diff[i];
            while (j < m && queries[j][0] == i)
            {
                pq.Enqueue(queries[j][1], -queries[j][1]);
                j++;
            }
            while (operations < nums[i] && pq.Count > 0 && pq.Peek() >= i)
            {
                operations += 1;
                diff[pq.Dequeue() + 1]--;
            }
            if (operations < nums[i]) return -1;
        }
        return pq.Count;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input1, CustomEnumerable<CustomEnumerable<int>> input2)
    {
        return MaxRemovalOptim(input1.ToArray(), input2.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<(CustomEnumerable<int>, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (new([2,0,2]), new([new([0,2]), new([0,2]), new([1,1])])),
            (new([1,1,1,1]), new([new([1,3]), new([0,2]), new([1,3]), new([1,2])])),
            (new([1,2,3,4]), new([new([0,3])])),
            (new([1,2]), new([new([1,1]), new([0,0]), new([1,1]), new([1,1]), new([0,1]), new([0,0])])),
            (new([0,0,1,1,0]), new([new([3,4]), new([0,2]), new([2,3])]))
            ];
    }
}
