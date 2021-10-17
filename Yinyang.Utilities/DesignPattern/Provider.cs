using System.Diagnostics;
using Yinyang.Utilities.Disposable;

namespace Yinyang.Utilities.DesignPattern
{
    [DebuggerStepThrough]
    public abstract class Provider : DisposableObject
    {
        public string Name { get; }

        protected Provider(string name) => Name = name;
    }
}
