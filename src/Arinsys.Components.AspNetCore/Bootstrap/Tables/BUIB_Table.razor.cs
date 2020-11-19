namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public class BUIB_TableDataFilters<TEntity> : BUI_TableDataFilters<TEntity> { }

    public partial class BUIB_Table<TEntity, TTableDataFilters> : BUI_Table<TEntity, TTableDataFilters>
        where TTableDataFilters : BUIB_TableDataFilters<TEntity>, new()
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ComponentCssClasses.Add("table");
        }
    }
}
