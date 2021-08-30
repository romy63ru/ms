using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArraysAndStrings;

namespace test.ArraysAndStrings
{
    [TestClass]
    class CCI1_1Test
    {
        [TestMethod]
        public void CCI1_1Test1()
        {
            Assert.IsFalse(CCI1_1.CheckString("abbbbbcccc"));
            Assert.IsFalse(CCI1_1.CheckString("abca"));
            Assert.IsTrue(CCI1_1.CheckString("abcd"));
            Assert.IsTrue(CCI1_1.CheckString("a"));
            Assert.IsTrue(CCI1_1.CheckString(""));
        }
    }
}
