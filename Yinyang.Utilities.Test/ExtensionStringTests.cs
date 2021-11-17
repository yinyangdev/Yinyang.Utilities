using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yinyang.Utilities.Test;

[TestClass]
public class ExtensionStringTests
{
    [TestMethod]
    public void LengthEqualTest()
    {
        var str = "12345";
        Assert.AreEqual(false, str.LengthEqual(4));
        Assert.AreEqual(true, str.LengthEqual(5));
        Assert.AreEqual(false, str.LengthEqual(6));

        str = "１２３４５";
        Assert.AreEqual(false, str.LengthEqual(4));
        Assert.AreEqual(true, str.LengthEqual(5));
        Assert.AreEqual(false, str.LengthEqual(6));

        str = "あいうえお";
        Assert.AreEqual(false, str.LengthEqual(4));
        Assert.AreEqual(true, str.LengthEqual(5));
        Assert.AreEqual(false, str.LengthEqual(6));

        str = string.Empty;
        Assert.AreEqual(false, str.LengthEqual(-1));
        Assert.AreEqual(true, str.LengthEqual(0));
        Assert.AreEqual(false, str.LengthEqual(1));

        str = null;
        Assert.ThrowsException<ArgumentNullException>(() => str.LengthEqual(0));

    }

    [TestMethod]
    public void LengthUnderTest()
    {
        var str = "12345";
        Assert.AreEqual(false, str.LengthUnder(4));
        Assert.AreEqual(false, str.LengthUnder(5));
        Assert.AreEqual(true, str.LengthUnder(6));

        str = "１２３４５";
        Assert.AreEqual(false, str.LengthUnder(4));
        Assert.AreEqual(false, str.LengthUnder(5));
        Assert.AreEqual(true, str.LengthUnder(6));

        str = "あいうえお";
        Assert.AreEqual(false, str.LengthUnder(4));
        Assert.AreEqual(false, str.LengthUnder(5));
        Assert.AreEqual(true, str.LengthUnder(6));

        str = string.Empty;
        Assert.AreEqual(false, str.LengthUnder(-1));
        Assert.AreEqual(false, str.LengthUnder(0));
        Assert.AreEqual(true, str.LengthUnder(1));

        str = null;
        Assert.ThrowsException<ArgumentNullException>(() => str.LengthUnder(0));

    }

    [TestMethod]
    public void LengthOverTest()
    {
        var str = "12345";
        Assert.AreEqual(true, str.LengthOver(4));
        Assert.AreEqual(false, str.LengthOver(5));
        Assert.AreEqual(false, str.LengthOver(6));

        str = "１２３４５";
        Assert.AreEqual(true, str.LengthOver(4));
        Assert.AreEqual(false, str.LengthOver(5));
        Assert.AreEqual(false, str.LengthOver(6));

        str = "あいうえお";
        Assert.AreEqual(true, str.LengthOver(4));
        Assert.AreEqual(false, str.LengthOver(5));
        Assert.AreEqual(false, str.LengthOver(6));

        str = string.Empty;
        Assert.AreEqual(true, str.LengthOver(-1));
        Assert.AreEqual(false, str.LengthOver(0));
        Assert.AreEqual(false, str.LengthOver(1));

        str = null;
        Assert.ThrowsException<ArgumentNullException>(() => str.LengthOver(0));

    }

    [TestMethod]
    public void LengthRangeTest()
    {
        var str = "12345";
        Assert.AreEqual(true, str.LengthRange(1,6));
        Assert.AreEqual(true, str.LengthRange(1, 5));
        Assert.AreEqual(false, str.LengthRange(1, 4));
        Assert.AreEqual(true, str.LengthRange(4, 10));
        Assert.AreEqual(true, str.LengthRange(5, 10));
        Assert.AreEqual(false, str.LengthRange(6, 10));

        str = "１２３４５";
        Assert.AreEqual(true, str.LengthRange(1, 6));
        Assert.AreEqual(true, str.LengthRange(1, 5));
        Assert.AreEqual(false, str.LengthRange(1, 4));
        Assert.AreEqual(true, str.LengthRange(4, 10));
        Assert.AreEqual(true, str.LengthRange(5, 10));
        Assert.AreEqual(false, str.LengthRange(6, 10));

        str = "あいうえお";
        Assert.AreEqual(true, str.LengthRange(1, 6));
        Assert.AreEqual(true, str.LengthRange(1, 5));
        Assert.AreEqual(false, str.LengthRange(1, 4));
        Assert.AreEqual(true, str.LengthRange(4, 10));
        Assert.AreEqual(true, str.LengthRange(5, 10));
        Assert.AreEqual(false, str.LengthRange(6, 10));

        str = string.Empty;
        Assert.AreEqual(true, str.LengthRange(-10, 1));
        Assert.AreEqual(true, str.LengthRange(-10, 0));
        Assert.AreEqual(false, str.LengthRange(-10, -1));
        Assert.AreEqual(true, str.LengthRange(-1, 10));
        Assert.AreEqual(true, str.LengthRange(0, 10));
        Assert.AreEqual(false, str.LengthRange(1, 10));

        str = null;
        Assert.ThrowsException<ArgumentNullException>(() => str.LengthRange(-10, 1));
    }

    [TestMethod]
    public void IsNumberTest()
    {
        var str = "12345";
        Assert.AreEqual(true, str.IsNumber());

        str = "12345-";
        Assert.AreEqual(false, str.IsNumber());

        str = "12a345";
        Assert.AreEqual(false, str.IsNumber());

        str = "１２３４５";
        Assert.AreEqual(false, str.IsNumber());

        str = "12あ345";
        Assert.AreEqual(false, str.IsNumber());

        str = string.Empty;
        Assert.AreEqual(false, str.IsNumber());

        str = null;
        Assert.ThrowsException<ArgumentNullException>(() => str.IsNumber());
    }

    [TestMethod]
    public void IsHalfWidthAlphanumericTest()
    {
        var str = "abc123";
        Assert.AreEqual(true, str.IsHalfWidthAlphanumeric());

        str = "abc123-";
        Assert.AreEqual(false, str.IsHalfWidthAlphanumeric());

        str = "abc-123";
        Assert.AreEqual(false, str.IsHalfWidthAlphanumeric());

        str = "abc０123";
        Assert.AreEqual(false, str.IsHalfWidthAlphanumeric());

        str = "abcあ123";
        Assert.AreEqual(false, str.IsHalfWidthAlphanumeric());

        str = string.Empty;
        Assert.AreEqual(false, str.IsHalfWidthAlphanumeric());

        str = null;
        Assert.ThrowsException<ArgumentNullException>(() => str.IsHalfWidthAlphanumeric());
    }

    [TestMethod]
    public void IsHalfWidthAlphanumericSymbolTest()
    {
        var str = "abc123!\"#$%&'()=~|`*+><_?>}";
        Assert.AreEqual(true, str.IsHalfWidthAlphanumericSymbol());

        str = "ＡＢＣ１２３";
        Assert.AreEqual(false, str.IsHalfWidthAlphanumericSymbol());

        str = "abc-123$%亜&'()=~|`*";
        Assert.AreEqual(false, str.IsHalfWidthAlphanumericSymbol());

        str = "abc０123$%&'()=~|`*";
        Assert.AreEqual(false, str.IsHalfWidthAlphanumericSymbol());

        str = "abcあ123$%&'()=~|`*";
        Assert.AreEqual(false, str.IsHalfWidthAlphanumericSymbol());

        str = string.Empty;
        Assert.AreEqual(false, str.IsHalfWidthAlphanumericSymbol());

        str = null;
        Assert.ThrowsException<ArgumentNullException>(() => str.IsHalfWidthAlphanumericSymbol());
    }

    [TestMethod]
    public void IsJapanPostalCodeTest()
    {
        var str = "123-4567";
        Assert.AreEqual(true, str.IsJapanPostalCode());

        str = "1-234567";
        Assert.AreEqual(false, str.IsJapanPostalCode());

        str = "１２３－４５６";
        Assert.AreEqual(false, str.IsJapanPostalCode());

        str = "1234567";
        Assert.AreEqual(false, str.IsJapanPostalCode());

        str = string.Empty;
        Assert.AreEqual(false, str.IsJapanPostalCode());

        str = null;
        Assert.ThrowsException<ArgumentNullException>(() => str.IsJapanPostalCode());
    }

    [TestMethod]
    public void IsRegexMatchTest()
    {
        var str = "123-4567";
        Assert.AreEqual(true, str.IsRegexMatch(@"\d"));
        Assert.AreEqual(true, str.IsRegexMatch(@"[0-9]"));
        Assert.AreEqual(true, str.IsRegexMatch(@"[!-~]"));
        Assert.AreEqual(true, str.IsRegexMatch(@"[!-/:-@¥[-`{-~]"));
        Assert.AreEqual(false, str.IsRegexMatch(@"[あ-ん]"));

        str = "あかさたな";
        Assert.AreEqual(false, str.IsRegexMatch(@"\d"));
        Assert.AreEqual(false, str.IsRegexMatch(@"[0-9]"));
        Assert.AreEqual(false, str.IsRegexMatch(@"[!-~]"));
        Assert.AreEqual(false, str.IsRegexMatch(@"[!-/:-@¥[-`{-~]"));
        Assert.AreEqual(true, str.IsRegexMatch(@"[あ-ん]"));

        str = null;
        Assert.ThrowsException<ArgumentNullException>(() => str.IsRegexMatch(@"^[0-9]{3}-[0-9]{4}$"));
    }

    [TestMethod]
    public void IsRegexIsMatchTest()
    {
        var str = "123-4567";
        Assert.AreEqual(true, str.IsRegexIsMatch(@"^[0-9]{3}-[0-9]{4}$"));

        str = "1-234567";
        Assert.AreEqual(false, str.IsRegexIsMatch(@"^[0-9]{3}-[0-9]{4}$"));

        str = "１２３－４５６";
        Assert.AreEqual(false, str.IsRegexIsMatch(@"^[0-9]{3}-[0-9]{4}$"));

        str = "1234567";
        Assert.AreEqual(false, str.IsRegexIsMatch(@"^[0-9]{3}-[0-9]{4}$"));

        str = string.Empty;
        Assert.AreEqual(false, str.IsRegexIsMatch(@"^[0-9]{3}-[0-9]{4}$"));

        str = null;
        Assert.ThrowsException<ArgumentNullException>(() => str.IsRegexIsMatch(@"^[0-9]{3}-[0-9]{4}$"));
    }
}
