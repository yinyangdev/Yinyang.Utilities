using System.Linq;

namespace Yinyang.Utilities
{
    /// <summary>
    ///     Random String Generator
    /// </summary>
    public class RandomString
    {
        public string Chars { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#$%&=~";

        public string Generate(int length)
        {
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}
