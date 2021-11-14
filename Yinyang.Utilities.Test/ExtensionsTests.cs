using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yinyang.Utilities.Test
{
    [TestClass]
    public class Enum
    {
        public enum MyEnum : long
        {
            Test1 = 1,
            Test2 = 10,
            Test3 = 20
        }

        [TestMethod]
        public void TryCastTest()
        {
            Assert.AreEqual(true, EnumUtility.TryCast(MyEnum.Test2, out long a, 0));
            Assert.AreEqual(10, a);
        }
    }
}
