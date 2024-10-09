using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems
{
    internal abstract class Solution<In, Out>
    {
        public abstract IEnumerable<In> TestCases();

        public abstract Out Execute(In input);

        public void Run()
        {
            foreach (var testcase in this.TestCases())
            {
                Console.WriteLine($"Input: {testcase}\nOutput: {this.Execute(testcase)}\n");
            }
        }
    }
}
