using System.Security.Cryptography;
using System.Text;

namespace Yinyang.Utilities.Hash
{
    /// <summary>
    ///     Convert SHA Utility
    /// </summary>
    public static class ConvertSHA
    {
        /// <summary>
        ///     String to SHA256
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>SHA256 string</returns>
        public static string StringToSHA256(string str)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(str));
            foreach (var theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }

        /// <summary>
        ///     String to SHA512
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>SHA512 string</returns>
        public static string StringToSHA512(string str)
        {
            var crypt = new SHA512Managed();
            var hash = new StringBuilder();
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(str));
            foreach (var theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
