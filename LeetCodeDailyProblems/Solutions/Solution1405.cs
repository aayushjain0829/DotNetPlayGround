using System.Text;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution1405 : Solution<int, int, int, string>
{
    #region Algos
    private string LongestDiverseString(int a, int b, int c)
    {
        StringBuilder sb = new StringBuilder();
        PriorityQueue<char, int> pq = new PriorityQueue<char, int>(3, Comparer<int>.Create((x, y) => y - x));
        if (a > 0) pq.Enqueue('a', a);
        if (b > 0) pq.Enqueue('b', b);
        if (c > 0) pq.Enqueue('c', c);

        while (pq.Count > 1)
        {
            pq.TryPeek(out char c1, out int p1);
            if (sb.Length > 1 && sb[^1] == c1 && sb[^2] == c1)
            {
                pq.Dequeue();
                pq.TryPeek(out char c2, out int p2);

                sb.Append(c2);

                pq.Dequeue();
                pq.Enqueue(c1, p1);
                if (p2 > 1) pq.Enqueue(c2, p2 - 1);
            }
            else
            {
                sb.Append(c1);

                pq.Dequeue();
                if (p1 > 1) pq.Enqueue(c1, p1 - 1);
            }
        }

        if(pq.Count == 1)
        {
            pq.TryPeek(out char c1, out int p1);
            sb.Append(c1);
            if (p1 > 1) sb.Append(c1);
        }

        return sb.ToString();
    }
    #endregion

    public override string Execute(int input1, int input2, int input3)
    {
        return LongestDiverseString(input1, input2, input3);
    }

    public override IEnumerable<(int, int, int)> TestCases()
    {
        return new List<(int, int, int)>()
        {
            new (1, 1, 7),
            new (7, 1, 0),
            new (7, 7, 7)
        };
    }
}
