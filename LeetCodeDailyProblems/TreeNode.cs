using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems;

internal class TreeNode<T> where T : struct
{
    public T val;
    public TreeNode<T>? left;
    public TreeNode<T>? right;

    public TreeNode(T val, TreeNode<T>? left = null, TreeNode<T>? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public TreeNode(IEnumerable<T?> arr)
    {
        if (arr == null || !arr.Any())
            throw new ArgumentException("Array cannot be null or empty");

        this.val = arr.First() ?? throw new ArgumentException("First element cannot be null");
        Queue<TreeNode<T>> queue = new();
        queue.Enqueue(this);

        for (int i = 1; i < arr.Count();)
        {
            TreeNode<T> current = queue.Dequeue();
            T? value = arr.ElementAt(i++);

            if (value != null)
            {
                current.left = new TreeNode<T>((T)value);
                queue.Enqueue(current.left);
            }

            if (i < arr.Count())
            {
                value = arr.ElementAt(i++);

                if (value != null)
                {
                    current.right = new TreeNode<T>((T)value);
                    queue.Enqueue(current.right);
                }
            }
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        Queue<TreeNode<T>?> queue = new();
        queue.Enqueue(this);

        sb.Append("[");
        while (queue.Count > 0 && queue.Any(node => node != null))
        {
            TreeNode<T>? node = queue.Dequeue();

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
