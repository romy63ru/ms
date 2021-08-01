using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace src
{
    [TestClass]
    public class ListsTest
    {
        [TestMethod]
        public void RemoveDuplicates2and1Test()
        {
            var lists = new Lists();
            var input = new LinkedList<int>();
            input.AddLast(2);
            input.AddLast(4);
            input.AddLast(1);
            input.AddLast(0);
            input.AddLast(7);
            input.AddLast(4);
            input.AddLast(2);
            input.AddLast(1);

            var result = lists.RemoveDuplicates2and1(input);
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result.First.Value, 2);
            Assert.AreEqual(result.Last.Value, 7);
        }

        [TestMethod]
        [Ignore]
        public void RemoveDuplicates2and1Testv2()
        {
            var lists = new Lists();
            var input = new LinkedList<int>();
            input.AddLast(2);
            input.AddLast(4);
            input.AddLast(1);
            input.AddLast(0);
            input.AddLast(7);
            input.AddLast(4);
            input.AddLast(2);
            input.AddLast(1);

            var result = lists.RemoveDuplicates2and1v2(input);
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result.First.Value, 2);
            Assert.AreEqual(result.Last.Value, 7);
        }
    }
}
