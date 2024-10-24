namespace LeetCodeDailyProblems.TreeNodes.Double;

internal class TreeNode : TreeNode<double>
{
    public new double val;
    public new TreeNode? left;
    public new TreeNode? right;

    public TreeNode(double val, TreeNode<double>? left = null, TreeNode<double>? right = null) : base(val, left, right)
    {
        this.val = base.val;
        this.left = (base.left == null) ? null : new TreeNode(base.left.val, base.left.left, base.left.right);
        this.right = (base.right == null) ? null : new TreeNode(base.right.val, base.right.left, base.right.right);
    }
}