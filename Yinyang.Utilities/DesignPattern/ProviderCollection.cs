using System;
using System.Diagnostics;
using System.Linq;
using Yinyang.Utilities.Disposable;

namespace Yinyang.Utilities.DesignPattern
{
    [DebuggerStepThrough]
    public abstract class ProviderCollection : DisposableCollection
    {
        protected Provider this[string name]
        {
            get
            {
                lock (SyncRoot)
                {
                    return InnerList.Cast<Provider>()
                        .FirstOrDefault(provider =>
                            string.Compare(provider.Name, name, StringComparison.OrdinalIgnoreCase) == 0);
                }
            }
        }

        protected override void DisposeOfManagedResources()
        {
            base.DisposeOfManagedResources();

            lock (SyncRoot)
            {
                foreach (Provider provider in InnerList)
                {
                    provider.Dispose();
                }

                InnerList.Clear();
            }
        }

        protected void Add(Provider provider)
        {
            if (Contains(provider))
            {
                throw new ProviderAlreadyExistsException(provider.Name);
            }

            lock (SyncRoot)
            {
                InnerList.Add(provider);
            }
        }

        protected void Remove(Provider provider)
        {
            if (!Contains(provider))
            {
                return;
            }

            lock (SyncRoot)
            {
                InnerList.Remove(provider);
            }
        }

        protected bool Contains(Provider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return this[provider.Name] != null;
        }

        public sealed class ProviderAlreadyExistsException : ApplicationException
        {
            public string ProviderName { get; }

            internal ProviderAlreadyExistsException(string name) :
                base($"A Provider with the name '{name}' already exists in the collection.") =>
                ProviderName = name;
        }
    }
}
