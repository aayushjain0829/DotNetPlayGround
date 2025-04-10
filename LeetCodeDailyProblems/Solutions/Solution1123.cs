
namespace LeetCodeDailyProblems.Solutions
{
    internal class Solution1123 : Solution<TreeNode, TreeNode>
    {
        #region Algos
        private TreeNode LcaDeepestLeaves(TreeNode root)
        {
            var dict = new Dictionary<int, (int par, TreeNode? node)>();
            var deepestLeaves = new List<int>();
            var maxDepth = 0;

            void Traverse(TreeNode node, int par, int depth)
            {
                dict[node.val] = (par, node);
                if (node.left == null && node.right == null)
                {
                    if (depth > maxDepth)
                    {
                        deepestLeaves.Clear();
                        maxDepth = depth;
                    }

                    if (depth == maxDepth) deepestLeaves.Add(node.val);
                }
                else
                {
                    if (node.left != null) Traverse(node.left, node.val, depth + 1);
                    if (node.right != null) Traverse(node.right, node.val, depth + 1);
                }
            }

            Traverse(root, -1, 0);
            while (deepestLeaves.Count > 1)
            {
                var lca = new HashSet<int>();
                foreach (var node in deepestLeaves) lca.Add(dict[node].par);
                deepestLeaves.Clear();
                foreach (var node in lca) deepestLeaves.Add(node);
            }

            return dict[deepestLeaves.First()].node!;
        }

        private TreeNode LcaDeepestLeavesOptim(TreeNode root)
        {
            Tuple<TreeNode?, int> dfs(TreeNode? node)
            {
                if (node == null)
                {
                    return new Tuple<TreeNode?, int>(null, 0);
                }

                Tuple<TreeNode?, int> left = dfs(node.left);
                Tuple<TreeNode?, int> right = dfs(node.right);

                if (left.Item2 > right.Item2)
                {
                    return new Tuple<TreeNode?, int>(left.Item1, left.Item2 + 1);
                }
                if (left.Item2 < right.Item2)
                {
                    return new Tuple<TreeNode?, int>(right.Item1, right.Item2 + 1);
                }
                return new Tuple<TreeNode?, int>(node, left.Item2 + 1);
            }

            return dfs(root).Item1!;
        }
        #endregion

        public override TreeNode Execute(TreeNode input)
        {
            return LcaDeepestLeavesOptim(input);
        }

        public override IEnumerable<TreeNode> TestCases()
        {
            return [
                new([3,5,1,6,2,0,8,null,null,7,4]),
                new([1]),
                new([0,1,3,null,2])
                ];
        }
    }
}
