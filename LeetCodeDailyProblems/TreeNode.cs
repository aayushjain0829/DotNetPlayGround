using System.Text;

namespace LeetCodeDailyProblems;

internal class TreeNode
{
    internal int val;
    internal TreeNode? left;
    internal TreeNode? right;

    public TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public TreeNode(IEnumerable<int?> arr)
    {
        if (arr == null || !arr.Any())
            throw new ArgumentException("Array cannot be null or empty");

        val = arr.First() ?? throw new ArgumentException("First element cannot be null");
        Queue<TreeNode> queue = new();
        queue.Enqueue(this);

        for (int i = 1; i < arr.Count();)
        {
            TreeNode current = queue.Dequeue();
            int? value = arr.ElementAt(i++);

            if (value != null)
            {
                current.left = new TreeNode((int)value);
                queue.Enqueue(current.left);
            }

            if (i < arr.Count())
            {
                value = arr.ElementAt(i++);

                if (value != null)
                {
                    current.right = new TreeNode((int)value);
                    queue.Enqueue(current.right);
                }
            }
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        Queue<TreeNode?> queue = new();
        queue.Enqueue(this);

        sb.Append("[");
        while (queue.Count > 0 && queue.Any(node => node != null))
        {
            TreeNode? node = queue.Dequeue();

            if (node == null)
            {
                sb.Append("null, ");
                continue;
            }

            sb.Append(node.val + ", ");
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }
        sb.Remove(sb.Length - 2, 2).Append("]");

        return sb.ToString();
    }
}