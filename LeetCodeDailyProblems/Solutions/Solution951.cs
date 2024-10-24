namespace LeetCodeDailyProblems.Solutions;

internal class Solution951 : Solution<TreeNode?, TreeNode?, bool>
{
    #region Algos
    private bool FlipEquiv(TreeNode? root1, TreeNode? root2)
    {
        if (root1 == null && root2 == null) return true;
        if (root1 == null || root2 == null) return false;
        if (root1.val != root2.val) return false;
        if ((FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right)) ||
                (FlipEquiv(root1.right, root2.left) && FlipEquiv(root1.left, root2.right))) return true;

        return false;
    }
    #endregion

    public override bool Execute(TreeNode? input1, TreeNode? input2)
    {
        return FlipEquiv(input1, input2);
    }

    public override IEnumerable<(TreeNode?, TreeNode?)> TestCases()
    {
        return new List<(TreeNode?, TreeNode?)>
        {
            (new TreeNode([1,2,3,4,5,6,null,null,null,7,8]), new TreeNode([1,3,2,null,6,4,5,null,null,null,null,8,7])),
            (null, null),
            (null, new TreeNode([1])),
        };
    }
}
