namespace LeetCodeDailyProblems.Solutions;

internal class Solution2583 : Solution<TreeNode, int, long>
{
    #region Algos
    private long KthLargestLevelSum(TreeNode root, int k)
    {
        List<long> lvls = [];
        Queue<TreeNode> q = new();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            long sum = 0;
            for(int i = q.Count; i > 0; i--)
            {
                TreeNode node = q.Dequeue();

                sum += node.val;
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
            lvls.Add(sum);
        }

        if (lvls.Count < k) return -1;
        lvls.Sort((a, b) => b.CompareTo(a));
        return lvls[k - 1];
    }
    #endregion

    public override long Execute(TreeNode input1, int input2)
    {
        return KthLargestLevelSum(input1, input2);
    }

    public override IEnumerable<(TreeNode, int)> TestCases()
    {
        return [
            (new TreeNode([5,8,9,2,1,3,7,4,6]), 2),
            (new TreeNode([1,2,null,3]), 1)
        ];
    }
}
