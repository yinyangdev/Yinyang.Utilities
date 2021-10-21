using System.Linq;

namespace Yinyang.Utilities
{
    public static class Extensions
    {
        /// <summary>
        ///     Copy Properties
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <typeparam name="TU">type</typeparam>
        /// <param name="source">Source object</param>
        /// <param name="dest">Dest object</param>
        public static void CopyPropertiesTo<T, TU>(T source, TU dest)
        {
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                .Where(x => x.CanWrite)
                .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if (p.CanWrite)
                    {
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }
            }
        }
    }
}
