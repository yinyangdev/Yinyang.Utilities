using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yinyang.Utilities.Test
{
    [TestClass]
    public class EnumCommentAttributeTests
    {
        public enum TestEnum
        {
            [EnumComment("テスト")] test,
            [EnumComment("テスト2")] test2
        }

        [TestMethod]
        public void EnumCommentAttributeTest()
        {
            Assert.AreEqual("テスト", TestEnum.test.GetEnumComment());
        }
    }
}
