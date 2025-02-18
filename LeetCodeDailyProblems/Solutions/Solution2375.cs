
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2375 : Solution<string, string>
{
    #region Algos
    private string SmallestNumber(string pattern)
    {
        var lst = new Stack<int>();
        bool[] vis = new bool[10];
        vis[0] = true;

        bool IsPossible(int idx)
        {
            if (idx == pattern.Length) return true;

            int curr = lst.Peek();
            for (int i = 1; i < 10; i++)
            {
                if ((!vis[i]) && ((i < curr && pattern[idx] == 'D') || (i > curr && pattern[idx] == 'I')))
                {
                    lst.Push(i);
                    vis[i] = true;
                    if (IsPossible(idx + 1)) return true;
                    vis[i] = false;
                    lst.Pop();
                }
            }

            return false;
        }

        for (int i = 1; i < 10; i++)
        {
            lst.Push(i);
            vis[i] = true;
            if (IsPossible(0)) break;
            vis[i] = false;
            lst.Pop();
        }

        string ans = "";
        while (lst.Count > 0) ans = lst.Pop().ToString() + ans;
        return ans;
    }
    #endregion

    public override string Execute(string input)
    {
        return SmallestNumber(input);
    }

    public override IEnumerable<string> TestCases()
    {
        return [
            "IIIDIDDD",
            "DDD"
            ];
    }
}
