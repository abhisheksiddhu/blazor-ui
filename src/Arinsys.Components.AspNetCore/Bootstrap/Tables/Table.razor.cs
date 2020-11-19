namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public partial class Table<TEntity, TTableDataFilters> : AspNetCore.Table<TEntity, TTableDataFilters>
        where TTableDataFilters : TableDataFilters<TEntity>, new()
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ComponentCssClasses.Add("table");
        }
    }
}
