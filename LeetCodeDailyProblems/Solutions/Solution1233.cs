
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1233 : Solution<CustomEnumerable<string>, CustomEnumerable<string>>
{
    #region Algos
    private class Trie
    {
        internal bool IsExist;
        internal Dictionary<string, Trie> SubFolders;

        public Trie()
        {
            IsExist = false;
            SubFolders = [];
        }
    }

    private IList<string> RemoveSubfolders(string[] folder)
    {
        Trie root = new();
        foreach (string folderPath in folder)
        {
            string[] folders = folderPath.Split(['/'], StringSplitOptions.RemoveEmptyEntries);
            Trie node = root;
            foreach (string folderName in folders)
            {
                if (!node.SubFolders.ContainsKey(folderName))
                {
                    node.SubFolders.Add(folderName, new Trie());
                }
                node = node.SubFolders[folderName];
                if (node.IsExist) break;
            }
            node.IsExist = true;
        }

        IList<string> ans = [];

        void Dfs(Trie node, string folderPath)
        {
            if (node.IsExist)
            {
                ans.Add(folderPath);
                return;
            }

            foreach (var kvp in node.SubFolders)
            {
                Dfs(kvp.Value, folderPath + "/" + kvp.Key);
            }
        }

        Dfs(root, "");
        return ans;
    }

    private IList<string> RemoveSubfoldersWithoutTrie(string[] folder)
    {
        List<string> answer = new();
        Array.Sort(folder);

        foreach (var f in folder)
        {
            if (answer.Count == 0 || f.StartsWith($"{answer[answer.Count - 1]}/") == false)
            {
                answer.Add(f);
            }
        }

        return answer;
    }
    #endregion

    public override CustomEnumerable<string> Execute(CustomEnumerable<string> input)
    {
        return new CustomEnumerable<string>(RemoveSubfoldersWithoutTrie(input.ToArray()));
    }

    public override IEnumerable<CustomEnumerable<string>> TestCases()
    {
        return [
            new(["/a","/a/b","/c/d","/c/d/e","/c/f"]),
            new(["/a","/a/b/c","/a/b/d"]),
            new(["/a/b/c","/a/b/ca","/a/b/d"])
        ];
    }
}
