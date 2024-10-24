namespace LeetCodeDailyProblems.Solutions;

internal class Solution2641 : Solution<TreeNode, TreeNode>
{
    #region Algos
    TreeNode ReplaceValueInTree(TreeNode root)
    {
        int prevSum = root.val;
        Queue<(TreeNode, int)> q = new();

        q.Enqueue((root, prevSum));
        while (q.Count > 0)
        {
            int currSum = 0;
            for (int i = q.Count; i > 0; i--)
            {
                (TreeNode node, int val) = q.Dequeue();
                int sum = ((node.left == null) ? 0 : node.left.val) + ((node.right == null) ? 0 : node.right.val);

                node.val = prevSum - val;
                currSum += sum;
                if (node.left != null) q.Enqueue((node.left, sum));
                if (node.right != null) q.Enqueue((node.right, sum));
            }

            prevSum = currSum;
        }

        return root;
    }
    #endregion

    public override TreeNode Execute(TreeNode input)
    {
        return ReplaceValueInTree(input);
    }

    public override IEnumerable<TreeNode> TestCases()
    {
        return [
            new TreeNode([5,4,9,1,10,null,7]),
            new TreeNode([3,1,2])
        ];
    }
}
