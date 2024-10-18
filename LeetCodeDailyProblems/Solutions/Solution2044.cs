using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems.Solutions
{
    internal class Solution2044 : Solution<CustomEnumerable<int>, int>
    {
        #region Algos
        private int CountMaxOrSubsets(int[] nums)
        {
            int maxVal = 0, valCount = 0, n = (int)Math.Pow(2, nums.Length);

            for (int i = 1; i < n; i++)
            {
                int val = 0;
                for (int j = 0; j < nums.Length; j++) if ((i & (1 << j)) > 0) val |= nums[j];

                if (maxVal == val) valCount++;
                else if (maxVal < val)
                {
                    maxVal = val;
                    valCount = 1;
                }
            }

            return valCount;
        }
        #endregion

        public override int Execute(CustomEnumerable<int> input)
        {
            return CountMaxOrSubsets(input.ToArray());
        }

        public override IEnumerable<CustomEnumerable<int>> TestCases()
        {
            return new List<CustomEnumerable<int>>()
            {
                new CustomEnumerable<int>([3,1]),
                new CustomEnumerable<int>([2,2,2]),
                new CustomEnumerable<int>([3,2,1,5])
            };
        }
    }
}
