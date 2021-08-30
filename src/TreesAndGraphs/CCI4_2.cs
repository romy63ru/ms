using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    /// <summary>
    /// 4.2 Minimal Tree: Given a sorted (increasing order) array with unique integer elements, write an algo­rithm to create a binary search tree with minimal height.
    /// </summary>
    public class CCI4_2
    {
        public static TreeNode CreateMinimalBST(int[] arr)
        {
            return CreateMinimalBST(arr, 0, arr.Length - 1);
        }

        public static TreeNode CreateMinimalBST(int[] arr, int start, int end)
        {
            if (end < start)
            {
                return null;
            }
            int mid = (start + end) / 2;
            TreeNode n = new TreeNode(arr[mid]);
            n.left = CreateMinimalBST(arr, start, mid - 1);
            n.right = CreateMinimalBST(arr, mid + 1, end);
            return n;
        }
    }
}
