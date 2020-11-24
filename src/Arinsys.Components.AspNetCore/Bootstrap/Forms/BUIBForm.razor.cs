namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public class BUIBFormDefinition<TEntity> : BUIFormDefinition<TEntity> { }

    public partial class BUIBForm<TEntity, TFormDefinition> : BUIForm<TEntity, TFormDefinition>
        where TFormDefinition : BUIFormDefinition<TEntity>
    {
    }
}
