using Yinyang.Utilities.DesignPattern;

namespace Yinyang.Utilities.Samples.DesignPattern
{
    /// <summary>
    ///     Singleton Class
    /// </summary>
    public class SingletonObjectClass : SingletonObject<SingletonObjectClass>
    {
        /// <summary>
        ///     Private Constructor
        /// </summary>
        private SingletonObjectClass() { }
    }

    /// <summary>
    ///     Singleton Sample
    /// </summary>
    public class Singleton
    {
        /// <summary>
        ///     Get Instance
        /// </summary>
        private SingletonObjectClass obj = SingletonObjectClass.Instance;
    }
}
