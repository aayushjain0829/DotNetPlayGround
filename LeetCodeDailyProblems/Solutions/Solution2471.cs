
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2471 : Solution<TreeNode, int>
{
    #region Algos
    private int MinSwapsToSort(int[] arr)
    {
        int n = arr.Length, swaps = 0;
        bool[] visited = new bool[n];
        var indexedArr = new (int val, int idx)[n];
        for (int i = 0; i < n; i++) indexedArr[i] = (arr[i], i);
        Array.Sort(indexedArr, (a, b) => a.val.CompareTo(b.val));

        for (int i = 0; i < n; i++)
        {
            if (visited[i] || indexedArr[i].idx == i) continue;

            int cycleSize = 0, j = i;
            while (!visited[j])
            {
                visited[j] = true;
                j = indexedArr[j].idx;
                cycleSize++;
            }

            if (cycleSize > 1) swaps += cycleSize - 1;
        }

        return swaps;
    }

    private int MinimumOperations(TreeNode root)
    {
        if (root == null) return 0;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int operations = 0;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            var level = new int[levelSize];
            for (int i = 0; i < levelSize; i++)
            {
                TreeNode node = queue.Dequeue();
                level[i] = node.val;

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            operations += MinSwapsToSort(level);
        }

        return operations;
    }
    #endregion

    public override int Execute(TreeNode input)
    {
        return MinimumOperations(input);
    }

    public override IEnumerable<TreeNode> TestCases()
    {
        return [
            new([1,4,3,7,6,8,5,null,null,null,null,9,null,10]),
            new([1,3,2,7,6,5,4]),
            new([1,2,3,4,5,6])
            ];
    }
}
