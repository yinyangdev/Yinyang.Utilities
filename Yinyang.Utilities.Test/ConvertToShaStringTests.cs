using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yinyang.Utilities.Hash;

namespace Yinyang.Utilities.Test
{
    [TestClass]
    public class ConvertToShaStringTests
    {
        [TestMethod]
        public void StringToSha256Test()
        {
            Assert.AreEqual("44a630d1ff6506506430c7df24b7ca63cdcaf3ab8347bcc67e46be08a4d330d2",
                ConvertSHA.StringToSHA256(
                    "oui%H3#HhJ&rgSVe^EbY$BG5@7fKVdKxAx!xdARRZn5YBPNG@FD#7#x5mPRRVB%toCVe&Pa!$VRQZm7MU#xMkKBo%hGA5uw$kB3aiAkwoA6R#s$cCXvnqfH7"));
            Assert.AreEqual("fdb481ea956fdb654afcc327cff9b626966b2abdabc3f3e6dbcb1667a888ed9a",
                ConvertSHA.StringToSHA256("あいうえお"));
        }

        [TestMethod]
        public void StringToSha512Test()
        {
            Assert.AreEqual(
                "409a5af60b7b922138c45649d141522c470dace9465f51b814107dd9ebcd60a530de2131c42f63a5d0744599f79e8150b913dcae772995579f96c982f106e230",
                ConvertSHA.StringToSHA512(
                    "oui%H3#HhJ&rgSVe^EbY$BG5@7fKVdKxAx!xdARRZn5YBPNG@FD#7#x5mPRRVB%toCVe&Pa!$VRQZm7MU#xMkKBo%hGA5uw$kB3aiAkwoA6R#s$cCXvnqfH7"));
            Assert.AreEqual(
                "ed8ad6b03b7cb459d0149093d38488c4ea667ad24d24ddf97fecefa6b704455c349301e452c4874e7f046cd3432de141e7391b1d3626cdd42959428f9ea8e863",
                ConvertSHA.StringToSHA512("あいうえお"));
        }
    }
}
