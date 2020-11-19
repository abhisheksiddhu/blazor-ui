namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public partial class BUIB_Table<TEntity, TTableDataFilters> : BUI_Table<TEntity, TTableDataFilters>
        where TTableDataFilters : TableDataFilters<TEntity>, new()
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ComponentCssClasses.Add("table");
        }
    }
}
