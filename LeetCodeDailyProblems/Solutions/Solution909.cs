
namespace LeetCodeDailyProblems.Solutions;

internal class Solution909 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private IList<int> ConvertToFlatBoard(int[][] board)
    {
        int n = board.Length;
        var flatBoard = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int row = n - 1 - i;
            for (int j = 0; j < n; j++)
            {
                int col = j;
                if (i % 2 == 1) col = n - 1 - j;
                flatBoard.Add(board[row][col]);
            }
        }

        return flatBoard;
    }

    private IList<int>[] GetAdjList(int[][] board)
    {
        var flatboard = ConvertToFlatBoard(board);
        var adjList = new List<int>[flatboard.Count];

        for (int i = 0; i < flatboard.Count; i++)
        {
            var nextSqrs = new List<int>();
            for (int j = 1; j < 7; j++)
            {
                if (i + j >= flatboard.Count) break;
                int nextSqr = (flatboard[i + j] == -1 ? i + j : flatboard[i + j] - 1);
                nextSqrs.Add(nextSqr);
            }
            adjList[i] = nextSqrs;
        }

        return adjList;
    }

    private int SnakesAndLadders(int[][] board)
    {
        int ans = 0;
        var adjList = GetAdjList(board);
        var vis = new bool[adjList.Length];
        var q = new Queue<int>();
        q.Enqueue(0);
        vis[0] = true;

        while (q.Count > 0)
        {
            int sz = q.Count;
            while (sz > 0)
            {
                sz--;
                var currSqr = q.Dequeue();
                if (currSqr == adjList.Length - 1) return ans;
                foreach (var nextSqr in adjList[currSqr])
                {
                    if (vis[nextSqr]) continue;
                    q.Enqueue(nextSqr);
                    vis[nextSqr] = true;
                }
            }
            ans++;
        }

        return -1;
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return SnakesAndLadders(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([-1,-1,-1,-1,-1,-1]),
                new([-1,-1,-1,-1,-1,-1]),
                new([-1,-1,-1,-1,-1,-1]),
                new([-1,35,-1,-1,13,-1]),
                new([-1,-1,-1,-1,-1,-1]),
                new([-1,15,-1,-1,-1,-1])]),
            new([new([-1,-1]), new([-1,3])])
            ];
    }
}
