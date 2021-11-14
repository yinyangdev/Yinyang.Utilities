using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yinyang.Utilities.Test
{
    [TestClass]
    public class RandomStringTests
    {
        [TestMethod]
        public void GenerateTest()
        {
            var r1 = new RandomString();
            var r2 = new RandomString();
            Assert.AreNotEqual(r1.Generate(60), r2.Generate(60));
        }
    }
}
