using System;
using System.Text.RegularExpressions;

namespace Yinyang.Utilities
{
    /// <summary>
    ///     ExtensionString
    /// </summary>
    public static class ExtensionString
    {
        /// <summary>
        ///     Check if the lengths match.
        /// </summary>
        /// <remarks>文字列の長さが指定値を一致するか比較します。</remarks>
        /// <param name="str">string</param>
        /// <param name="length">length</param>
        /// <returns>result</returns>
        /// <exception cref="ArgumentNullException">string is null</exception>
        public static bool LengthEqual(this string str, int length)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            return str.Length == length;
        }

        /// <summary>
        ///     Check if the length is under.
        /// </summary>
        /// <remarks>文字列の長さが指定値を超か比較します。</remarks>
        /// <param name="str">string</param>
        /// <param name="length">length</param>
        /// <returns>result</returns>
        /// <exception cref="ArgumentNullException">string is null</exception>
        public static bool LengthUnder(this string str, int length)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            return str.Length < length;
        }

        /// <summary>
        ///     Check if the length is over.
        /// </summary>
        /// <remarks>文字列の長さが指定値を未満か比較します。</remarks>
        /// <param name="str">string</param>
        /// <param name="length">length</param>
        /// <returns>result</returns>
        /// <exception cref="ArgumentNullException">string is null</exception>
        public static bool LengthOver(this string str, int length)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            return length < str.Length;
        }

        /// <summary>
        ///     Check if the length is range.
        /// </summary>
        /// <remarks>文字列の長さが指定値未満、指定値超か比較します。</remarks>
        /// <param name="str">string</param>
        /// <param name="minLength">min length</param>
        /// <param name="maxLength">max length</param>
        /// <returns>result</returns>
        /// <exception cref="ArgumentNullException">string is null</exception>
        public static bool LengthRange(this string str, int minLength, int maxLength)
        {
            if (maxLength <= minLength)
            {
                throw new ArgumentNullException();
            }

            return !(str.LengthUnder(minLength) || str.LengthOver(maxLength));
        }

        /// <summary>
        ///     is a number
        /// </summary>
        /// <remarks>文字列が数値であるか比較します。</remarks>
        /// <param name="str">string</param>
        /// <returns>result</returns>
        /// <exception cref="ArgumentNullException">string is null</exception>
        public static bool IsNumber(this string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            return Regex.IsMatch(str, @"^[0-9]+$");
        }

        /// <summary>
        ///     is a half-width alphanumeric
        /// </summary>
        /// <remarks>文字列が半角英数字であるか比較します。</remarks>
        /// <param name="str">string</param>
        /// <returns>result</returns>
        public static bool IsHalfWidthAlphanumeric(this string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            return Regex.IsMatch(str, @"^[0-9a-zA-Z]+$");
        }

        /// <summary>
        ///     is a half-width alphanumeric symbol
        /// </summary>
        /// <remarks>文字列が半角英数字記号であるか比較します。</remarks>
        /// <param name="str">string</param>
        /// <returns>result</returns>
        public static bool IsHalfWidthAlphanumericSymbol(this string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            return Regex.IsMatch(str, @"^[!-~]+$");
        }

        /// <summary>
        ///     is a japan postalcode
        /// </summary>
        /// <remarks>文字列が日本の郵便番号形式であるか比較します。</remarks>
        /// <param name="str">string</param>
        /// <returns>result</returns>
        public static bool IsJapanPostalCode(this string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            return Regex.IsMatch(str, @"^[0-9]{3}-[0-9]{4}$");
        }

        /// <summary>
        ///     is a regex match
        /// </summary>
        /// <remarks>指定した正規表現に一致する箇所が見つかるかどうか示します。</remarks>
        /// <param name="str">string</param>
        /// <param name="pattern">pattern</param>
        /// <returns>result</returns>
        public static bool IsRegexMatch(this string str, string pattern)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            return Regex.Match(str, pattern, RegexOptions.ECMAScript).Success;
        }

        /// <summary>
        ///     is a regex is match
        /// </summary>
        /// <remarks>指定した正規表現に一致する箇所が見つかるかどうか示します。</remarks>
        /// <param name="str">string</param>
        /// <param name="pattern">pattern</param>
        /// <returns>result</returns>
        public static bool IsRegexIsMatch(this string str, string pattern)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            return Regex.IsMatch(str, pattern);
        }
    }
}
