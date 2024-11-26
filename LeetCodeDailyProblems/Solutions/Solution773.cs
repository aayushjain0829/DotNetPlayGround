
namespace LeetCodeDailyProblems.Solutions;

internal class Solution773 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private readonly Dictionary<string, int> dist = [];
    private readonly int[][] swapOptions = [[1, 5], [0, 2, 4], [1, 3], [2, 4], [1, 3, 5], [0, 4]];
    private const string target = "123054";

    public Solution773()
    {
        if (dist.Count > 0) return;

        var q = new Queue<string>();
        dist[target] = 0;
        q.Enqueue(target);

        while (q.Count > 0)
        {
            for (int i = q.Count; i > 0; i--)
            {
                string s = q.Dequeue();
                int currDist = dist[s] + 1;
                int idxOfZero = s.IndexOf('0');
                
                foreach (var idxToSwap in swapOptions[idxOfZero])
                {
                    var arr = s.ToCharArray();
                    arr[idxOfZero] = arr[idxToSwap];
                    arr[idxToSwap] = '0';
                    string t = new(arr);

                    if (!dist.ContainsKey(t))
                    {
                        dist[t] = currDist;
                        q.Enqueue(t);
                    }
                }
            }
        }
    }

    private int SlidingPuzzle(int[][] board)
    {
        string s = $"{board[0][0]}{board[0][1]}{board[0][2]}{board[1][2]}{board[1][1]}{board[1][0]}";
        return dist.GetValueOrDefault(s, -1);
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return SlidingPuzzle(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([1,2,3]), new([4,0,5])]),
            new([new([1,2,3]), new([5,4,0])]),
            new([new([4,1,2]), new([5,0,3])])
            ];
    }
}
