﻿namespace LeetCodeDailyProblems;

internal abstract class Solution<In, Out>
{
    public abstract IEnumerable<In> TestCases();

    public abstract Out Execute(In input);

    public void Run()
    {
        foreach (var testcase in TestCases())
        {
            Console.WriteLine($"Input: \n\n{testcase?.ToString() ?? "null"}\n\nOutput: {Execute(testcase)}\n");
        }
    }
}

internal abstract class Solution<In1, In2, Out>
{
    public abstract IEnumerable<(In1, In2)> TestCases();

    public abstract Out Execute(In1 input1, In2 input2);

    public void Run()
    {
        foreach (var testcase in TestCases())
        {
            Console.WriteLine($"Input: \n\n{testcase.Item1?.ToString() ?? "null"}\n{testcase.Item2?.ToString() ?? "null"}\n\nOutput: {Execute(testcase.Item1, testcase.Item2)}\n");
        }
    }
}

internal abstract class Solution<In1, In2, In3, Out>
{
    public abstract IEnumerable<(In1, In2, In3)> TestCases();

    public abstract Out Execute(In1 input1, In2 input2, In3 input3);

    public void Run()
    {
        foreach (var testcase in TestCases())
        {
            Console.WriteLine($"Input: \n\n{testcase.Item1?.ToString() ?? "null"}\n{testcase.Item2?.ToString() ?? "null"}\n{testcase.Item3?.ToString() ?? "null"}\n\nOutput: {Execute(testcase.Item1, testcase.Item2, testcase.Item3)}\n");
        }
    }
}

internal abstract class Solution<In1, In2, In3, In4, Out>
{
    public abstract IEnumerable<(In1, In2, In3, In4)> TestCases();

    public abstract Out Execute(In1 input1, In2 input2, In3 input3, In4 input4);

    public void Run()
    {
        foreach (var testcase in TestCases())
        {
            Console.WriteLine($"Input: \n\n{testcase.Item1?.ToString() ?? "null"}\n{testcase.Item2?.ToString() ?? "null"}\n{testcase.Item3?.ToString() ?? "null"}\n{testcase.Item4?.ToString() ?? "null"}\n\nOutput: {Execute(testcase.Item1, testcase.Item2, testcase.Item3, testcase.Item4)}\n");
        }
    }
}
