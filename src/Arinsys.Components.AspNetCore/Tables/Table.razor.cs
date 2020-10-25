using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace Arinsys.Components.AspNetCore.Tables
{
    public class TableDataFilters<TEntity>
    {

    }

    public partial class Table<TEntity, TTableDataFilters> : BaseComponent where TTableDataFilters : TableDataFilters<TEntity>, new()
    {
        internal readonly BehaviorSubject<object> filtersUpdated = new BehaviorSubject<object>(null);

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
                ChangeStateOn(FiltersUpdated.Do(filters => DataAccessor(filters)));
            }
        }
    }
}
