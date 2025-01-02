
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2559 : Solution<CustomEnumerable<string>, CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<int>>
{
    #region Algos
    private bool IsVowel(char ch)
        => (ch == 'a') || (ch == 'e') || (ch == 'i') || (ch == 'o') || (ch == 'u');

    private int[] VowelStrings(string[] words, int[][] queries)
    {
        int n = words.Length;
        var validWords = new bool[n];
        var cumValidWords = new int[n + 1];

        for (int i=0; i < n; i++)
        {
            validWords[i] = IsVowel(words[i].First()) && IsVowel(words[i].Last());
            cumValidWords[i+1] = cumValidWords[i] + (validWords[i] ? 1 : 0);
        }

        int m = queries.Length;
        var res = new int[m];
        for (int i = 0; i < m; i++) res[i] = cumValidWords[queries[i][1] + 1] - cumValidWords[queries[i][0]];

        return res;
    }
    #endregion

    public override CustomEnumerable<int> Execute(CustomEnumerable<string> input1, CustomEnumerable<CustomEnumerable<int>> input2)
    {
        return new(VowelStrings(input1.ToArray(), input2.Select(x => x.ToArray()).ToArray()));
    }

    public override IEnumerable<(CustomEnumerable<string>, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (new(["aba","bcb","ece","aa","e"]), new([new([0,2]), new([1,4]), new([1,1])])),
            (new(["a","e","i"]), new([new([0,2]), new([0,1]), new([2,2])]))
            ];
    }
}
