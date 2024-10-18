using System.Collections;
using System.Text;

namespace LeetCodeDailyProblems;

internal class CustomEnumerable<T> : IEnumerable<T>
{
    private readonly IEnumerable<T> _enumerable;

    public CustomEnumerable(IEnumerable<T> enumerable)
    {
        _enumerable = enumerable;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _enumerable.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _enumerable.GetEnumerator();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"[{string.Join(", ", _enumerable)}]");
        return sb.ToString();
    }
}
