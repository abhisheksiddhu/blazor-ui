using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Arinsys.Components.AspNetCore
{
    public abstract class BaseLayout : LayoutComponentBase, IDisposable
    {
        private readonly List<IDisposable> subscriptions = new List<IDisposable>();

        protected void ChangeStateOn(IObservable<object> observable)
        {
            subscriptions.Add(observable.Subscribe(onNext: async nextValue => await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false)));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    subscriptions.ForEach(subscription => subscription.Dispose());
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseComponent()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
