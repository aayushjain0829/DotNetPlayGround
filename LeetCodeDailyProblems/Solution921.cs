using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems
{
    internal class Solution921 : Solution<string, int>
    {
        public int MinAddToMakeValid(string s)
        {
            int ans = 0;
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == ')')
                {
                    if ((!stack.TryPeek(out char topChar) || topChar != '(')) ans++;
                    else stack.Pop();
                }
                else stack.Push(c);
            }

            return ans + stack.Count;
        }

        public override int Execute(string input)
        {
            return MinAddToMakeValid(input);
        }

        public override IEnumerable<string> TestCases()
        {
            return new List<string>() {
                "())",
                "((("
            };
        }
    }
}
