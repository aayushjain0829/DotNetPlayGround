using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems.Solutions
{
    internal class Solution2938 : Solution<string, long>
    {
        private long MinimumSteps(string s)
        {
            long pos = s.Length, ans = 0;
            foreach (char ch in s) if (ch == '1') pos--;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1') ans += pos++ - i;
            }

            return ans;
        }

        private long MinimumStepsLINQ(string s)
        {
            long pos = s.Length - s.Count(c => c == '1');
            long ans = s.Select((character, index) => (character, index))
                        .Where(tuple => tuple.character == '1')
                        .Aggregate(0L, (accumulator, tuple) => accumulator + pos++ - tuple.index);

            return ans;
        }

        public override long Execute(string input)
        {
            return MinimumStepsLINQ(input);
        }

        public override IEnumerable<string> TestCases()
        {
            return new List<string>()
            {
                "101",
                "100",
                "0111"
            };
        }
    }
}
