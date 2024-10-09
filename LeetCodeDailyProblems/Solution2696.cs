using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems
{
    internal class Solution2696 : Solution<string, int>
    {
        public int MinLength(string s)
        {
            // return MinLengthRecursion(s);
            // return MinLengthStack(s);
            return MinLengthAggreate(s);
        }

        #region Algos

        private  int MinLengthRecursion(string s)
        {
            int n = s.Length;
            string updated = "";

            for (int i = 0; i < n; i++)
            {
                if (i < n - 1 && ((s[i] == 'A' && s[i + 1] == 'B') || (s[i] == 'C' && s[i + 1] == 'D'))) i++;
                else updated += s[i];
            }

            if (s.Equals(updated)) return n;
            return MinLengthRecursion(updated);
        }

        private int MinLengthStack(string s)
        {
            int n = s.Length;
            Stack<char> stk = new Stack<char>(n);

            foreach (char ch in s)
            {
                if (stk.Count > 0 && ((stk.Peek() == 'A' && ch == 'B') || (stk.Peek() == 'C' && ch == 'D'))) stk.Pop();
                else stk.Push(ch);
            }

            return stk.Count;
        }

        private int MinLengthAggreate(string s)
        {
            return s.Aggregate(new Stack<char>(), (stack, nextCh) =>
            {
                if (stack.Count > 0 && (stack.Peek() == 'A' && nextCh == 'B' || stack.Peek() == 'C' && nextCh == 'D'))
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(nextCh);
                }
                return stack;
            }).Count;
        }

        #endregion

        public override int Execute(string input)
        {
            return MinLength(input);
        }

        public override IEnumerable<string> TestCases()
        {
            return new List<string>() { 
                "ABFCACDB",
                "ACBBD",
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB"
            };
        }
    }
}
