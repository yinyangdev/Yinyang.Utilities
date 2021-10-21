namespace Yinyang.Utilities
{
    /// <summary>
    ///     Enum Utility
    /// </summary>
    public static class EnumUtility
    {
        /// <summary>
        /// Enum TryCast
        /// </summary>
        /// <typeparam name="T">Enum Type</typeparam>
        /// <param name="value">Value</param>
        /// <param name="result">Result</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns></returns>
        public static bool TryCast<T>(object value, out T result, T defaultValue) where T : struct
        {
            result = defaultValue;
            try
            {
                result = (T)value;
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }
    }
}
