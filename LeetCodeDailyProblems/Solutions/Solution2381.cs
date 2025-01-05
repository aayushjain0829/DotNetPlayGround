
using System.Text;

namespace LeetCodeDailyProblems.Solutions;

internal class Solution2381 : Solution<string, CustomEnumerable<CustomEnumerable<int>>, string>
{
    #region Algos
    private char doShift(char ch, int places)
    {
        int newCh = ch + places - 'a';
        newCh = ((newCh % 26) + 26) % 26;
        return (char)(newCh + 'a');
    }

    private string ShiftingLetters(string s, int[][] shifts)
    {
        int n = s.Length;
        var shift = new int[n+1];

        foreach ( var i in shifts )
        {
            shift[i[0]] += i[2] * 2 - 1;
            shift[i[1] + 1] += i[2] * -2 + 1;
        }

        int curr = 0;
        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            curr += shift[i];
            sb.Append(doShift(s[i], curr));
        }

        return sb.ToString();
    }
    #endregion

    public override string Execute(string input1, CustomEnumerable<CustomEnumerable<int>> input2)
    {
        return ShiftingLetters(input1, input2.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<(string, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            ("abc", new([ new([0,1,0]), new([1,2,1]), new([0,2,1]) ])),
            ("dztz", new([ new([0,0,0]), new([1,1,1]) ]))
            ];
    }
}
