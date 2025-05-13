

namespace LeetCodeDailyProblems.Solutions;

internal class Solution3335 : Solution<string, int, int>
{
    #region Algos
    private int LengthAfterTransformations(string s, int t)
    {
        int sum = 0, mod = 1000000007;
        int[] freq = new int[26];
        foreach (char ch in s) freq[ch - 'a']++;

        var lst = new LinkedList<int>();
        foreach (var i in freq) lst.AddFirst(i);
        for (int i = 0; i < t; i++)
        {
            int z = lst.First!.Value;
            int a = lst.Last!.Value;

            lst.Last!.Value = (a + z) % mod;
            lst.AddLast(z);
            lst.RemoveFirst();
        }

        foreach (var i in lst) sum = (sum + i) % mod;
        return sum;
    }
    #endregion

    public override int Execute(string input1, int input2)
    {
        return LengthAfterTransformations(input1, input2);
    }

    public override IEnumerable<(string, int)> TestCases()
    {
        return [
            ("abcyy", 2),
            ("azbk", 1)
            ];
    }
}
