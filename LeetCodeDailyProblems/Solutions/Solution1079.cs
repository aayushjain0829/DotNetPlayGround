
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1079 : Solution<string, int>
{
    #region Algos
    private int NumTilePossibilities(string tiles)
    {
        int n = (1 << tiles.Length);
        var hSet = new HashSet<string>();

        void Swap(char[] chars, int i, int j)
        {
            char temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
        }

        void GetAllPermutations(char[] chars, int start)
        {
            if (start == chars.Length - 1)
            {
                hSet.Add(new string(chars));
                return;
            }

            HashSet<char> seen = new HashSet<char>();

            for (int i = start; i < chars.Length; i++)
            {
                if (seen.Contains(chars[i])) continue;
                seen.Add(chars[i]);

                Swap(chars, start, i);
                GetAllPermutations(chars, start + 1);
                Swap(chars, start, i);
            }
        }

        for (int i=1; i<n; i++)
        {
            string s = "";
            for (int j=0; j<tiles.Length; j++)
            {
                if ((i & (1 << j)) > 0)
                    s += tiles[j];
            }
            GetAllPermutations(s.ToCharArray(), 0);
        }

        return hSet.Count;
    }
    #endregion

    public override int Execute(string input)
    {
        return NumTilePossibilities(input);
    }

    public override IEnumerable<string> TestCases()
    {
        return [
            "AAB",
            "AAABBC",
            "V"
            ];
    }
}
