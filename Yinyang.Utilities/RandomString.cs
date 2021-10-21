using System.Linq;

namespace Yinyang.Utilities
{
    /// <summary>
    ///     Random String Generator
    /// </summary>
    public class RandomString
    {
        /// <summary>
        ///     Random string chars
        /// </summary>
        public string Chars { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#$%&=~";

        /// <summary>
        ///     Generate
        /// </summary>
        /// <param name="length">String length</param>
        /// <returns>Random string value.</returns>
        public string Generate(int length)
        {
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}
