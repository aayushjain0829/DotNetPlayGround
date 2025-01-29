
namespace LeetCodeDailyProblems.Solutions;

internal class Solution684 : Solution<CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<int>>
{
    #region Algos
    private int[] FindRedundantConnection(int[][] edges)
    {
        int n = edges.Length;
        var par = new int[n];
        var rank = new int[n];
        int[] candidate = new int[2];

        for (int i = 0; i < n; i++)
        {
            par[i] = i;
            rank[i] = 1;
        }

        int GetPar(int x) => par[x] = (par[x] == x) ? x : GetPar(par[x]);

        foreach (var edge in edges)
        {
            int pa = GetPar(edge[0] - 1), pb = GetPar(edge[1] - 1);
            if (pa != pb)
            {
                if (rank[pa] < rank[pb])
                {
                    par[pa] = pb;
                    rank[pb] += rank[pa];
                }
                else
                {
                    par[pb] = pa;
                    rank[pa] += rank[pb];
                }
            }
            else candidate = edge;
        }

        return candidate;
    }
    #endregion

    public override CustomEnumerable<int> Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return new(FindRedundantConnection(input.Select(x => x.ToArray()).ToArray()));
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([1,2]), new([1,3]), new([2,3])]),
            new([new([1,2]), new([2,3]), new([3,4]), new([1,4]), new([1,5])])
            ];
    }
}
