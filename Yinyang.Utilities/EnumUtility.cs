namespace Yinyang.Utilities
{
    /// <summary>
    ///     Enum Utility
    /// </summary>
    public static class EnumUtility
    {
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
