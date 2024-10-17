using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems.Solutions
{
    internal class Solution670 : Solution<int, int>
    {
        #region Algos
        private int MaximumSwap(int num)
        {
            var digits = num.ToString().ToCharArray();
            int[] last = new int[10];

            for (int i = 0; i < digits.Length; i++)
            {
                last[digits[i] - '0'] = i;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                for (int d = 9; d > digits[i] - '0'; d--)
                {
                    if (last[d] > i)
                    {
                        (digits[i], digits[last[d]]) = (digits[last[d]], digits[i]);
                        return Convert.ToInt32(new string(digits));
                    }
                }
            }

            return num;
        }
        #endregion

        public override int Execute(int input)
        {
            return MaximumSwap(input);
        }

        public override IEnumerable<int> TestCases()
        {
            return new List<int>()
            {
                2736,
                9973,
                98368
            };
        }
    }
}
