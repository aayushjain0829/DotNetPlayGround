using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems.Solutions
{
    internal class Solution1545 : Solution<int, int, char>
    {
        #region Algos
        private char FindKthBit(int n, int k)
        {
            var lengths = Enumerable.Range(0, n)
                                .Select(i => (int)Math.Pow(2, i + 1) - 1)
                                .ToArray();

            int idx = k-1;
            bool invert = false;

            for (int i = n - 2; i >= 0; i--)
            {
                int mid = lengths[i + 1] / 2;
                if (idx == mid) return invert ? '0' : '1';
                if (idx > mid)
                {
                    idx = 2 * mid - idx;
                    invert = !invert;
                }
            }

            return invert ? '1' : '0';
        }
        #endregion

        public override char Execute(int input1, int input2)
        {
            return FindKthBit(input1, input2);
        }

        public override IEnumerable<(int, int)> TestCases()
        {
            return new List<(int, int)> { (3, 1), (3, 2), (3, 3), (3, 4), (3, 5), (3, 6), (3, 7) };

        }
    }
}
