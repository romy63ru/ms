using System;
namespace leetcode
{


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public bool IsValidBST(TreeNode root, TreeNode min = null, TreeNode max = null)
        {
            bool result = true;
            if (min != null)
            {
                result = result && root.val > min.val;
            }
            if (root.left != null)
            {
                result = result && IsValidBST(root.left, min, root);
            }
            if (max != null)
            {
                result = result && root.val < max.val;
            }
            if (root.right != null)
            {
                result = result && IsValidBST(root.right, root, max);
            }
            return result;
        }
    }
}
