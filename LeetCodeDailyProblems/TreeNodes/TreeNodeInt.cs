namespace LeetCodeDailyProblems.TreeNodes.Int;
internal class TreeNode : TreeNode<int>
{
    public new int val;
    public new TreeNode? left;
    public new TreeNode? right;

    public TreeNode(int val, TreeNode<int>? left = null, TreeNode<int>? right = null) : base(val, left, right)
    {
        this.val = base.val;
        this.left = (base.left == null) ? null : new TreeNode(base.left.val, base.left.left, base.left.right);
        this.right = (base.right == null) ? null : new TreeNode(base.right.val, base.right.left, base.right.right);
    }
}