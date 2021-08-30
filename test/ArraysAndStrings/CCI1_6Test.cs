using ArraysAndStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test.ArraysAndStrings
{
    [TestClass]
    class CCI1_6Test
    {
        [TestMethod]
        public void CCI1_1Test6()
        {
            Assert.AreEqual(CCI1_6.CompressString("aabcccccaaa"), "a2b1c5a3");
        }
    }
}
