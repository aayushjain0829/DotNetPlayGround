
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2415 : Solution<TreeNode, TreeNode>
{
    #region Algos
    private TreeNode ReverseOddLevels(TreeNode root)
    {
        bool even = true;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int m = queue.Count;
            var ints = new Stack<int>();
            var nodes = new Queue<TreeNode>();

            for (int i = 0; i < m; i++)
            {
                TreeNode node = queue.Dequeue();
                if (!even)
                {
                    ints.Push(node.val);
                    nodes.Enqueue(node);
                }

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            while (ints.Count > 0) nodes.Dequeue().val = ints.Pop();
            even = !even;
        }

        return root;
    }
    #endregion

    public override TreeNode Execute(TreeNode input)
    {
        return ReverseOddLevels(input);
    }

    public override IEnumerable<TreeNode> TestCases()
    {
        return [
            new([2,3,5,8,13,21,34]),
            new([7,13,11]),
            new([0,1,2,0,0,0,0,1,1,1,1,2,2,2,2])
            ];
    }
}
