namespace LeetCodeDailyProblems;

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
