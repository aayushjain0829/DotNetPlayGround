using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems.Solutions
{
    internal class Solution2530 : Solution<IntArray_Num, long>
    {
        public long MaxKelements(int[] nums, int k)
        {
            long ans = 0;
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(k, Comparer<int>.Create((x, y) => y - x));
            foreach (int i in nums) priorityQueue.Enqueue(i, i);
            for (int i = 0; i < k; i++)
            {
                int val = priorityQueue.Dequeue();
                ans += val;

                int newVal = (int)Math.Ceiling((double)val / 3);
                priorityQueue.Enqueue(newVal, newVal);
            }

            return ans;
        }

        public override long Execute(IntArray_Num input)
        {
            return MaxKelements(input.nums, input.k);
        }

        public override IEnumerable<IntArray_Num> TestCases()
        {
            return new List<IntArray_Num>()
            {
                new IntArray_Num (new int[]{ 10,10,10,10,10 }, 5),
                new IntArray_Num (new int[]{ 1,10,3,3,3 }, 3)
            };
        }
    }
}
