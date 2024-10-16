using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems.Solutions
{
    internal class Solution1405 : Solution<ListToString<int>, string>
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

        public override string Execute(ListToString<int> input)
        {
            return LongestDiverseString(input[0], input[1], input[2]);
        }

        public override IEnumerable<ListToString<int>> TestCases()
        {
            return new List<ListToString<int>>()
            {
                new ListToString<int>() { 1, 1, 7 },
                new ListToString<int>() { 7, 1, 0 },
                new ListToString<int>() { 7, 7, 7 }
            };
        }
    }
}
