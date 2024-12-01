
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2577 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int MinimumTime(int[][] grid)
    {
        if (grid[0][1] > 1 && grid[1][0] > 1) return -1;

        int m = grid.Length, n = grid[0].Length, currT = 0;
        int[][] dirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];
        var vis = new bool[m, n];
        var q = new Queue<(int x, int y)>();
        var pq = new PriorityQueue<(int x, int y), int>();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] % 2 != (i + j) % 2) grid[i][j]++;
            }
        }

        q.Enqueue((0, 0));
        vis[0,0] = true;

        while (q.Count > 0)
        {
            int a = q.Count;
            while (a-- > 0)
            {
                (int x, int y) = q.Dequeue();
                if (x == m - 1 && y == n - 1) return currT;
                foreach (var dir in dirs)
                {
                    int h = x + dir[0], k = y + dir[1];
                    if (h >= 0 && h < m && k >= 0 && k < n && !vis[h, k])
                    {
                        if (grid[h][k] <= currT + 1)
                        {
                            vis[h, k] = true;
                            q.Enqueue((h, k));
                        } else
                        {
                            pq.Enqueue((h, k), grid[h][k]);
                        }
                        
                    }
                }
            }

            currT++;
            if (q.Count == 0 && pq.TryPeek(out (int x, int y) _, out int minNextT))
            {
                currT = Math.Max(currT, minNextT);
            }

            while (pq.TryPeek(out (int x, int y) _, out int nextEleT) && nextEleT <= currT)
            {
                (int x, int y) = pq.Dequeue();
                if (!vis[x, y])
                {
                    vis[x, y] = true;
                    q.Enqueue((x, y));
                }
            }
        }

        return -1;
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return MinimumTime(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new([new([0,1,3,2]), new([5,1,2,5]), new([4,3,8,6])]),
            new([new([0,2,4]), new([3,2,1]), new([1,0,4])])
            ];
    }
}
