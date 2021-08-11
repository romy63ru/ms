using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode
{
    [TestClass]
    public class LeetCode1TestClass
    {
        [TestMethod]
        public void LeetCode1Test()
        {
            var left = new TreeNode(1);
            var right = new TreeNode(3);
            var root = new TreeNode(2, left, right);

            var s = new Solution();
            Assert.IsTrue(s.IsValidBST(root));
        }

        [TestMethod]
        public void LeetCode1Test1()
        {
            //[5,4,6,null,null,3,7]

            var left1 = new TreeNode(3);
            var right1 = new TreeNode(7);
            var left = new TreeNode(4);
            var right = new TreeNode(6, left1, right1);
            var root = new TreeNode(5, left, right);

            var s = new Solution();
            Assert.IsFalse(s.IsValidBST(root));
        }
    }
}
