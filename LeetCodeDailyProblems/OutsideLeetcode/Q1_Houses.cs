using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems.OutsideLeetcode
{
    internal class Q1_Houses : Solution<CustomEnumerable<int>, CustomEnumerable<int>>
    {
        private int[] MaxHouses(int[] queries)
        {
            int currMax = 0;
            List<int> values = new List<int>();
            Dictionary<int, int> parent = new Dictionary<int, int>();
            Dictionary<int, int> parentValue = new Dictionary<int, int>();

            foreach (var query in queries)
            {
                if (parent.ContainsKey(query + 1))
                {
                    parent[query] = parent[query + 1];
                    parentValue[parent[query]]++;
                }
                else if (parent.ContainsKey(query - 1))
                {
                    parent[query] = parent[query - 1];
                    parentValue[parent[query]]++;
                }
                else
                {
                    parent[query] = query;
                    parentValue[query] = 1;
                }
                currMax = Math.Max(currMax, parentValue[parent[query]]);
                values.Add(currMax);
            }

            return values.ToArray();
        }

        public override CustomEnumerable<int> Execute(CustomEnumerable<int> input)
        {
            return new CustomEnumerable<int>(MaxHouses(input.ToArray()));
        }

        public override IEnumerable<CustomEnumerable<int>> TestCases()
        {
            return new List<CustomEnumerable<int>>()
            {
                new CustomEnumerable<int>([2, 1, 3]),
                new CustomEnumerable<int>([1, 3 ,0, 4]), // 1122
                new CustomEnumerable<int>([2, 5, 1, 6, 8]) // 11222
            };
        }
    }
}
