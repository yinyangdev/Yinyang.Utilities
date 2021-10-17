using System;
using System.Diagnostics;
using System.Reflection;

namespace Yinyang.Utilities.DesignPattern
{
    [DebuggerStepThrough]
    public class SingletonObject<T> where T : class
    {
        public static T Instance => Nested.Instance;

        #region Nested type: Nested

        private sealed class Nested
        {
            internal static readonly T Instance;

            static Nested()
            {
                var ci = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes,
                    null);

                if (ci == null)
                {
                    throw new InvalidOperationException("class must contain a private constructor");
                }

                Instance = (T)ci.Invoke(null);
            }

            private Nested()
            {
            }
        }

        #endregion
    }
}
