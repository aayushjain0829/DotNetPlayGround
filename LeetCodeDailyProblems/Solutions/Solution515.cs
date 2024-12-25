namespace LeetCodeDailyProblems.Solutions;

internal class Solution515 : Solution<TreeNode, CustomEnumerable<int>>
{
    #region Algos
    private IList<int> LargestValues(TreeNode root)
    {
        var q = new Queue<TreeNode>();
        var ans = new List<int>();
        if (root != null) q.Enqueue(root);

        while (q.Count > 0)
        {
            int mx = int.MinValue, m = q.Count;
            while (m-- > 0)
            {
                var node = q.Dequeue();
                mx = Math.Max(mx, node.val);

                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }

            ans.Add(mx);
        }

        return ans;
    }
    #endregion

    public override CustomEnumerable<int> Execute(TreeNode input)
    {
        return new(LargestValues(input));
    }

    public override IEnumerable<TreeNode> TestCases()
    {
        return [
            new([1,3,2,5,3,null,9]),
            new([1,2,3])
            ];
    }
}
