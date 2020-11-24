namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public class BUIBTableDataFilters<TEntity> : BUITableDataFilters<TEntity> { }

    public partial class BUIBTable<TEntity, TTableDataFilters> : BUITable<TEntity, TTableDataFilters>
        where TTableDataFilters : BUIBTableDataFilters<TEntity>, new()
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ComponentCssClasses.Add("table");
        }
    }
}
