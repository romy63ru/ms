using System.Collections.Generic;
using Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test.Lists
{
    [TestClass]
    public class CCI2_1Test
    {
        [TestMethod]
        public void RemoveDuplicates2and1Test()
        {
            var input = new LinkedList<int>();
            input.AddLast(2);
            input.AddLast(4);
            input.AddLast(1);
            input.AddLast(0);
            input.AddLast(7);
            input.AddLast(4);
            input.AddLast(2);
            input.AddLast(1);

            var result = CCI2_1.RemoveDuplicates2and1(input);
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result.First.Value, 2);
            Assert.AreEqual(result.Last.Value, 7);
        }

        [TestMethod]
        [Ignore]
        public void RemoveDuplicates2and1Testv2()
        {
            var input = new LinkedList<int>();
            input.AddLast(2);
            input.AddLast(4);
            input.AddLast(1);
            input.AddLast(0);
            input.AddLast(7);
            input.AddLast(4);
            input.AddLast(2);
            input.AddLast(1);

            var result = CCI2_1.RemoveDuplicates2and1v2(input);
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result.First.Value, 2);
            Assert.AreEqual(result.Last.Value, 7);
        }
    }
}
