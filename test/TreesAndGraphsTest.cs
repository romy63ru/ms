using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace src
{
    [TestClass]
    public class TreesAndGraphsTest
    {
        [TestMethod]
        public void Task4and1Test()
        {
            var cl = new TreesAndGraphs();

            var g1 = new Graph();
            var node1 = new Node() { Name = "1" };
            var node2 = new Node() { Name = "2" };
            var node3 = new Node() { Name = "3" };

            g1.Nodes[0] = node1;
            g1.Nodes[1] = node2;
            g1.Nodes[2] = node3;

            node1.Children[0] = node2;


            Assert.IsFalse(cl.Task4and1(g1, node1, node3));


            node2.Children[0] = node3;


            Assert.IsTrue(cl.Task4and1(g1, node1, node3));
        }

        [TestMethod]
        public void Task4and2Test()
        {
            var cl = new TreesAndGraphs();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 12, 18 };
            var res = cl.CreateMinimalBST(arr);
            Assert.AreEqual(res.value, 4);
         }
    }
}
