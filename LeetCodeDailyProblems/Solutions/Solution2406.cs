using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems.Solutions
{
    internal class Solution2406 : Solution<IntArray2D, int>
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

        public override int Execute(IntArray2D input)
        {
            return MinGroups(input.ints);
        }

        public override IEnumerable<IntArray2D> TestCases()
        {
            return new List<IntArray2D> {
                new IntArray2D([[5, 10], [6, 8], [1, 5], [2, 3], [1, 10]]),
                new IntArray2D([[1, 3], [5, 6], [8, 10], [11, 13]]),
            };
        }
    }
}
