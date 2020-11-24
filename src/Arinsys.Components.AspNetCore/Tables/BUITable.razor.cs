using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace Arinsys.Components.AspNetCore
{
    public class BUITableDataFilters<TEntity>
    {

    }

    public partial class BUITable<TEntity, TTableDataFilters> : BaseComponent where TTableDataFilters : BUITableDataFilters<TEntity>, new()
    {
        internal readonly BehaviorSubject<object> filtersUpdated = new(null);

        [Parameter]
        public virtual Func<TTableDataFilters, Task<IEnumerable<TEntity>>> DataAccessor { get; set; }

        [Parameter]
        public RenderFragment<TEntity> Body { get; set; }

        [Parameter]
        public RenderFragment Head { get; set; }

        [Parameter]
        public RenderFragment Loading { get; set; }

        public IObservable<TTableDataFilters> FiltersUpdated => filtersUpdated.Select(_ => TableDataFilters);
        public TTableDataFilters TableDataFilters { get; private set; } = new TTableDataFilters();

        public void TriggerFiltersUpdated()
        {
            filtersUpdated.OnNext(null);
        }

        protected IEnumerable<TEntity> Data { get; private set; }
        protected TTableDataFilters Filters { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (DataAccessor != null)
            {
                ChangeStateOn(FiltersUpdated.Select(filters => DataAccessor(filters)).Concat().Do(data => Data = data));
            }
        }
    }
}
