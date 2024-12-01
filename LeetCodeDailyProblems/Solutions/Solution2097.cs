
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2097 : Solution<CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<CustomEnumerable<int>>>
{
    #region Algos
    private int[][] ValidArrangement(int[][] pairs)
    {
        // Build adjacency list, indegree and outdegree
        var adj = new Dictionary<int, Queue<int>>();
        var balance = new Dictionary<int, int>();

        foreach (var pair in pairs)
        {
            int u = pair[0];
            int v = pair[1];

            if (!adj.TryGetValue(u, out var ngbr))
            {
                ngbr = new Queue<int>();
                adj[u] = ngbr;
            }
            ngbr.Enqueue(v);
            balance[u] = balance.GetValueOrDefault(u) + 1;
            balance[v] = balance.GetValueOrDefault(v) - 1;
        }

        // find start node
        int start = pairs[0][0];
        foreach (var (key, value) in balance)
        {
            if (value == 1)
            {
                start = key;
                break;
            }
        }

        // DFS
        List<int> path = new List<int>();
        Stack<int> stack = new Stack<int>();
        stack.Push(start);

        while (stack.Count > 0)
        {
            int curr = stack.Peek();
            if (adj.TryGetValue(curr, out var ngbr) && ngbr.Count > 0)
            {
                stack.Push(ngbr.Dequeue());
                if (ngbr.Count == 0) adj.Remove(curr);
            }
            else
            {
                path.Add(curr);
                stack.Pop();
            }
        }

        // Build result
        var result = new List<int[]>();
        for (int i = path.Count - 1; i > 0; i--)
        {
            result.Add([path[i], path[i-1]]);
        }

        return result.ToArray();
    }
    #endregion

    public override CustomEnumerable<CustomEnumerable<int>> Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return new(ValidArrangement(input.Select(x => x.ToArray()).ToArray()).Select(x => new CustomEnumerable<int>(x)));
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([5,1]), new([4,5]), new([11,9]), new([9,4])]),
            new([new([1,3]), new([3,2]), new([2,1])]),
            new([new([1,2]), new([1,3]), new([2,1])])
            ];
    }
}
