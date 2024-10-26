namespace LeetCodeDailyProblems.Solutions;

internal class Solution2458 : Solution<TreeNode, CustomEnumerable<int>, CustomEnumerable<int>>
{
    #region Algos

    private class TreeNodeExtended : TreeNode
    {
        internal int valBST;
        internal int leftHeight;
        internal int rightHeight;

        public TreeNodeExtended(TreeNode node, int valueBST = 0) : base(node.val, node.left, node.right)
        {
            this.valBST = valueBST;
            this.leftHeight = 0;
            this.rightHeight = 0;
        }

        internal int GetHeight() { return Math.Max(leftHeight, rightHeight) + 1; }
    }

    private int[] TreeQueries(TreeNode root, int[] queries)
    {
        int currVal = 0;
        List<int> result = new();
        TreeNodeExtended extendedRoot = new(root);
        Dictionary<int, int> bstValues = new();

        void PreOrderTraverse(TreeNode node, TreeNodeExtended extendedNode)
        {
            if (node.left != null)
            {
                extendedNode.left = new TreeNodeExtended(node.left);
                PreOrderTraverse(node.left, (TreeNodeExtended)extendedNode.left);
                extendedNode.leftHeight = (extendedNode.left as TreeNodeExtended)!.GetHeight();
            }

            extendedNode.valBST = currVal++;
            bstValues.Add(extendedNode.val, extendedNode.valBST);
            
            if (node.right != null)
            {
                extendedNode.right = new TreeNodeExtended(node.right);
                PreOrderTraverse(node.right, (TreeNodeExtended)extendedNode.right);
                extendedNode.rightHeight = (extendedNode.right as TreeNodeExtended)!.GetHeight();
            }
        }

        PreOrderTraverse(root, extendedRoot);

        int Dfs(TreeNodeExtended node, int bstVal)
        {
            if(node.left != null && (node.left as TreeNodeExtended)!.valBST == bstVal)
            {
                return node.rightHeight + 1;
            }

            if (node.right != null && (node.right as TreeNodeExtended)!.valBST == bstVal)
            {
                return node.leftHeight + 1;
            }

            if (bstVal < node.valBST) return Math.Max(node.rightHeight, Dfs((node.left as TreeNodeExtended)!, bstVal)) + 1;
            return Math.Max(node.leftHeight, Dfs((node.right as TreeNodeExtended)!, bstVal)) + 1;
        }

        foreach (int query in queries)
        {
            result.Add(Dfs(extendedRoot, bstValues[query]) - 1);
        }

        return result.ToArray();
    }

    private int[] TreeQueriesOptim(TreeNode root, int[] queries)
    {
        var dict = new Dictionary<int, int>();
        int maxDepth = 0;

        Traverse(root, 0, isLeftToRight: true);
        maxDepth = 0; // Reset maxDepth for the second traversal
        Traverse(root, 0, isLeftToRight: false);

        return Array.ConvertAll(queries, q => dict[q]);

        void Traverse(TreeNode node, int depth, bool isLeftToRight)
        {
            if (node == null) return;

            dict[node.val] = Math.Max(dict.GetValueOrDefault(node.val, 0), maxDepth);
            maxDepth = Math.Max(maxDepth, depth);

            if (isLeftToRight)
            {
                Traverse(node.left!, depth + 1, isLeftToRight);
                Traverse(node.right!, depth + 1, isLeftToRight);
            }
            else
            {
                Traverse(node.right!, depth + 1, isLeftToRight);
                Traverse(node.left!, depth + 1, isLeftToRight);
            }
        }
    }

    #endregion

    public override CustomEnumerable<int> Execute(TreeNode input1, CustomEnumerable<int> input2)
    {
        return new CustomEnumerable<int>(TreeQueriesOptim(input1, input2.ToArray()));
    }

    public override IEnumerable<(TreeNode, CustomEnumerable<int>)> TestCases()
    {
        return
        [
            (new ([1,3,4,2,null,6,5,null,null,null,null,null,7]), new ([4])),
            (new ([5,8,9,2,1,3,7,4,6]), new ([3,2,4,8])),
        ];
    }
}
