using System;
using System.Collections.Generic;

namespace leetcode
{
    public class LeetCode2
    {
        class Solution
        {
            public IList<IList<int>> levelOrder(TreeNode root)
            {
                IList<IList<int>> levels = new List<IList<int>>();
                if (root == null) return levels;

                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                int level = 0;
                while (queue.Count != 0)
                {
                    // start the current level
                    levels.Add(new List<int>());

                    // number of elements in the current level
                    int level_length = queue.Count;
                    for (int i = 0; i < level_length; ++i)
                    {
                        TreeNode node = queue.Dequeue();

                        // fulfill the current level
                        levels[level].Add(node.val);

                        // add child nodes of the current level
                        // in the queue for the next level
                        if (node.left != null) queue.Enqueue(node.left);
                        if (node.right != null) queue.Enqueue(node.right);
                    }
                    // go to next level
                    level++;
                }
                return (IList<IList<int>>)levels;
            }
        }
    }
}
