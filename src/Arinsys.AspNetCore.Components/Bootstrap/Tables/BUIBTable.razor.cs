namespace Arinsys.AspNetCore.Components.Bootstrap
{
    public record BUIBTableDataResult<TEntity> : BUITableDataResult<TEntity> { }

    public record BUIBTableColumnDefinition<TEntity> : BUITableColumnDefinition<TEntity> { }

    public record BUIBTableDataFilters<TEntity> : BUITableDataFilters<TEntity> { }

    public partial class BUIBTable<TEntity, TTableDataFilters, TTableColumnDefinition, TTableDataResult> : BUITable<TEntity, TTableDataFilters, TTableColumnDefinition, TTableDataResult>
        where TTableDataFilters : BUIBTableDataFilters<TEntity>, new()
        where TTableColumnDefinition : BUIBTableColumnDefinition<TEntity>
        where TTableDataResult : BUIBTableDataResult<TEntity>
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ComponentCssClasses.Add("table");
        }
    }
}
