using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace src
{
    [TestClass]
    public class ArraysAndStringsTest
    {
        [TestMethod]
        public void CheckStringTest1a1()
        {
            var t = new ArraysAndStrings();
            Assert.IsFalse(ArraysAndStrings.CheckString("abbbbbcccc"));
            Assert.IsFalse(ArraysAndStrings.CheckString("abca"));
            Assert.IsTrue(ArraysAndStrings.CheckString("abcd"));
            Assert.IsTrue(ArraysAndStrings.CheckString("a"));
            Assert.IsTrue(ArraysAndStrings.CheckString(""));
        }
    }
}
