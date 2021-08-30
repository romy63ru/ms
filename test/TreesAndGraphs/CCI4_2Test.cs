using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreesAndGraphs;

namespace test.TreesAndGraphs
{
    [TestClass]
    public class CCI4_2Test
    {
        [TestMethod]
        public void CreateMinimalBSTTest()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 12, 18 };
            var res = CCI4_2.CreateMinimalBST(arr);
            Assert.AreEqual(res.value, 4);
        }
    }
}
