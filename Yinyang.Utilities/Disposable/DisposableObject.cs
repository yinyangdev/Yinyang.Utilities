using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Yinyang.Utilities.Disposable
{
    [DebuggerStepThrough]
    [Serializable]
    public abstract class DisposableObject : IDisposable
    {
        [Browsable(false)] public bool Disposed { get; private set; }

        [Browsable(false)] public object SyncRoot { get; } = new object();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeOfManagedResources()
        {
        }

        protected virtual void DisposeOfUnManagedResources()
        {
        }

        private void Dispose(bool disposing)
        {
            lock (SyncRoot)
            {
                if (!Disposed)
                {
                    if (disposing)
                        DisposeOfManagedResources();

                    DisposeOfUnManagedResources();

                    Disposed = true;
                }
            }
        }
    }
}
