using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Arinsys.Components.AspNetCore
{
    public class BaseComponent : ComponentBase, IDisposable
    {
        /// <summary>
        /// Gets a list of CSS classes that gets combined and added to the <c>class</c> attribute. Derived components should 
        /// typically use this value to override the primary HTML element's 'class' attribute.
        /// </summary>
        public ObservableCollection<string> ComponentCssClasses { get; private set; } = new ObservableCollection<string>();

        /// <summary>
        /// Gets a CSS class string that combines the <see cref="ComponentCssClasses"/>
        /// properties. Derived components should typically use this value for the primary HTML element's
        /// 'class' attribute.
        /// </summary>
        public string CssClass { get; private set; }

        private readonly List<IDisposable> subscriptions = new List<IDisposable>();

        protected void ChangeStateOn(IObservable<object> observable)
        {
            subscriptions.Add(observable.Subscribe(onNext: async nextValue => await TriggerStateChange()));
        }

        protected void ChangeStateOn<TCollectionEntity>(ObservableCollection<TCollectionEntity> observableCollection)
        {
            observableCollection.CollectionChanged += async (_, __) => await TriggerStateChange();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ComponentCssClasses.CollectionChanged += async (_, __) =>
            {
                CssClass = string.Join(" ", ComponentCssClasses);
                await TriggerStateChange();
            };
        }

        protected ConfiguredTaskAwaitable TriggerStateChange()
        {
            return InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
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
