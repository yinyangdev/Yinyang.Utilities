using System;
using System.Security.Cryptography;
using System.Threading;

namespace Yinyang.Utilities
{
    /// <summary>
    ///     Random Utility
    /// </summary>
    public static class Random
    {
        private static readonly ThreadLocal<System.Random> RandomWrapper = new ThreadLocal<System.Random>(() =>
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var buffer = new byte[sizeof(int)];
                rng.GetBytes(buffer);
                var seed = BitConverter.ToInt32(buffer, 0);
                return new System.Random(seed);
            }
        });

        /// <summary>
        ///     Get Random
        /// </summary>
        /// <returns>System.Random</returns>
        public static System.Random GetRandom()
        {
            return RandomWrapper.Value;
        }

        /// <summary>
        ///     NextBytes
        /// </summary>
        /// <param name="buffer">buffer</param>
        public static void NextBytes(byte[] buffer)
        {
            GetRandom().NextBytes(buffer);
        }

        /// <summary>
        ///     NextDouble
        /// </summary>
        /// <returns>Random double value.</returns>
        public static double NextDouble()
        {
            return GetRandom().NextDouble();
        }

        /// <summary>
        ///     Next
        /// </summary>
        /// <returns>Random int value.</returns>
        public static int Next()
        {
            return GetRandom().Next();
        }

        /// <summary>
        ///     Next
        /// </summary>
        /// <param name="maxValue">Max Value</param>
        /// <returns>Random int value.</returns>
        public static int Next(int maxValue)
        {
            return GetRandom().Next(maxValue);
        }

        /// <summary>
        ///     Next
        /// </summary>
        /// <param name="minValue">Min Value</param>
        /// <param name="maxValue">Max Value</param>
        /// <returns>Random int value.</returns>
        public static int Next(int minValue, int maxValue)
        {
            return GetRandom().Next(minValue, maxValue);
        }
    }
}
