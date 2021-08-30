using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreesAndGraphs;

namespace test.TreesAndGraphs
{
    [TestClass]
    public class CCI4_1Test
    {
        [TestMethod]
        public void Task4and1Test()
        {
            var g1 = new Graph();
            var node1 = new Node() { Name = "1" };
            var node2 = new Node() { Name = "2" };
            var node3 = new Node() { Name = "3" };

            g1.Nodes[0] = node1;
            g1.Nodes[1] = node2;
            g1.Nodes[2] = node3;

            node1.Children[0] = node2;

            Assert.IsFalse(CCI4_1.Task4and1(g1, node1, node3));

            node2.Children[0] = node3;

            Assert.IsTrue(CCI4_1.Task4and1(g1, node1, node3));
        }
    }
}
