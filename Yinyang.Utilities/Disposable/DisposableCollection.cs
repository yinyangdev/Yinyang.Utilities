using System;
using System.Collections;
using System.Diagnostics;

namespace Yinyang.Utilities.Disposable
{
    [DebuggerStepThrough]
    [Serializable]
    public abstract class DisposableCollection : CollectionBase, IDisposable
    {
        public bool Disposed { get; private set; }

        public object SyncRoot => InnerList.SyncRoot;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeOfManagedResources()
        {
            lock (SyncRoot)
            {
                foreach (var obj in InnerList)
                {
                    if (obj is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                }

                InnerList.Clear();
            }
        }

        protected virtual void DisposeOfUnManagedResources()
        {
        }

        public virtual void Sort(IComparer comparer)
        {
            lock (SyncRoot)
            {
                InnerList.Sort(comparer);
            }
        }

        private void Dispose(bool disposing)
        {
            lock (SyncRoot)
            {
                if (!Disposed)
                {
                    if (disposing)
                    {
                        DisposeOfManagedResources();
                    }

                    DisposeOfUnManagedResources();
                }

                Disposed = true;
            }
        }
    }
}
