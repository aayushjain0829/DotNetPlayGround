using System.Text;

namespace LeetCodeDailyProblems;

internal class ListToString<T> : List<T>
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        foreach (var i in this) sb.Append(i.ToString() + ", ");
        sb.Append("]");
        return sb.ToString();
    }
}
