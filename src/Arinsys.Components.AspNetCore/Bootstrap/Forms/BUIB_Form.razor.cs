namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public class BUIB_FormDefinition<TEntity> : BUI_FormDefinition<TEntity> { }

    public partial class BUIB_Form<TEntity, TFormDefinition> : BUI_Form<TEntity, TFormDefinition>
        where TFormDefinition : BUI_FormDefinition<TEntity>
    {
    }
}
