using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace src
{
    [TestClass]
    public class ArraysAndStringsTest
    {
        [TestMethod]
        public void CheckStringTest1a1()
        {
            Assert.IsFalse(ArraysAndStrings.CheckString("abbbbbcccc"));
            Assert.IsFalse(ArraysAndStrings.CheckString("abca"));
            Assert.IsTrue(ArraysAndStrings.CheckString("abcd"));
            Assert.IsTrue(ArraysAndStrings.CheckString("a"));
            Assert.IsTrue(ArraysAndStrings.CheckString(""));
        }

        [TestMethod]
        public void CompressStringTest1a6()
        {
            Assert.AreEqual(ArraysAndStrings.CompressString("aabcccccaaa"), "a2b1c5a3");
        }
    }
}
