using System.Text;

namespace LeetCodeDailyProblems;

internal struct IntArray_Num
{
    public int[] nums { get; private set; }
    public int k { get; private set; }

    public IntArray_Num(int[] _nums, int _k)
    {
        nums = _nums; k = _k;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("\nNums: ");
        foreach (int i in nums) sb.Append(i + ", ");
        sb.Append($"\nK: {k}");
        return sb.ToString();
    }
};

internal struct IntArray2D
{
    public int[][] ints { get; private set; }

    public IntArray2D(int[][] _ints)
    {
        ints = _ints;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        foreach (var row in ints)
        {
            sb.Append($"[{string.Join(", ", row)}], ");
        }
        sb.Append("]");
        return sb.ToString();
    }
};