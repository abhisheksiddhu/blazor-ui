using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace Arinsys.AspNetCore.Components
{
    public record BUITableColumnDefinition<TEntity>
    {
        public string Label { get; init; }
        public RenderFragment Header { get; init; }
        public Func<TEntity, object> Accessor { get; init; }
        public RenderFragment<TEntity> Body { get; init; }
    }

    public record BUITableDataResult<TEntity>
    {
        /// <summary> The items to provide. </summary>
        public IEnumerable<TEntity> Items { get; init; }
        /// <summary> The total item count in the source generating the items provided. </summary>
        public int TotalItemCount { get; init; }
    }

    public record BUITableDataFilters<TEntity>
    {
        /// <summary> The start index of the data segment requested. </summary>
        public int StartIndex { get; set; }
        /// <summary> The requested number of items to be provided. The actual number of provided items does not need to match this value. </summary>
        public int Count { get; set; }
        /// <summary> The <see cref="System.Threading.CancellationToken" /> used to relay cancellation of the request. </summary>
        public CancellationToken CancellationToken { get; set; }
    }

    public partial class BUITable<TEntity, TTableDataFilters, TTableColumnDefinition, TTableDataResult> : BaseComponent
        where TTableDataFilters : BUITableDataFilters<TEntity>, new()
        where TTableColumnDefinition : BUITableColumnDefinition<TEntity>
        where TTableDataResult : BUITableDataResult<TEntity>
    {
        internal readonly BehaviorSubject<object> filtersUpdated = new(null);

        [Parameter]
        public virtual Func<TTableDataFilters, Task<TTableDataResult>> DataAccessor { get; set; }

        [Parameter]
        public RenderFragment<TEntity> Body { get; set; }

        [Parameter]
        public RenderFragment Head { get; set; }

        [Parameter]
        public RenderFragment Loading { get; set; }

        [Parameter]
        public IEnumerable<TTableColumnDefinition> Columns { get; set; }

        public IObservable<TTableDataFilters> FiltersUpdated => filtersUpdated.Select(_ => Filters);
        public TTableDataFilters Filters { get; private set; } = new();

        public void TriggerFiltersUpdated()
        {
            filtersUpdated.OnNext(null);
        }

        protected virtual async ValueTask<ItemsProviderResult<TEntity>> ItemsProvider(ItemsProviderRequest request)
        {
            Filters = Filters with { StartIndex = request.StartIndex, Count = request.Count, CancellationToken = request.CancellationToken };

            TriggerFiltersUpdated();

            TTableDataResult tableDataResult = await DataAccessor(Filters);

            return new(tableDataResult.Items, tableDataResult.TotalItemCount);
        }
    }
}
