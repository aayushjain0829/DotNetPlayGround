
namespace LeetCodeDailyProblems.Solutions;

internal class Solution3160 : Solution<int, CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<int>>
{
    #region Algos
    private int[] QueryResults(int limit, int[][] queries)
    {
        var dict = new Dictionary<int, int>();
        var map = new Dictionary<int, HashSet<int>>();
        var ans = new List<int>();
        
        foreach (var query in queries)
        {
            if (dict.TryGetValue(query[0], out int prevColor)) 
            { 
                map[prevColor].Remove(query[0]); 
                if (map[prevColor].Count == 0) map.Remove(prevColor);
            }

            if (!map.ContainsKey(query[1]))
            {
                map[query[1]] = new HashSet<int>();
            }

            map[query[1]].Add(query[0]);
            dict[query[0]] = query[1];
            ans.Add(map.Count);
        }

        return ans.ToArray();
    }
    #endregion

    public override CustomEnumerable<int> Execute(int input1, CustomEnumerable<CustomEnumerable<int>> input2)
    {
        return new(QueryResults(input1, input2.Select(x => x.ToArray()).ToArray()));
    }

    public override IEnumerable<(int, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (4, new([new([1,4]), new([2,5]), new([1,3]), new([3,4])])),
            (4, new([new([0,1]), new([1,2]), new([2,2]), new([3,4]), new([4,5])]))
            ];
    }
}
