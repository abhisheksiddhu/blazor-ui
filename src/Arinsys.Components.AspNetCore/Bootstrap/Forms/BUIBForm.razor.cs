using Microsoft.AspNetCore.Components;

using System.Linq;

namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public interface IBUIBFormDefinition : IBUIFormDefinition
    {
        GridColumnSpan LabelColumnSpan { get; set; }
        GridColumnSpan InputColumnSpan { get; set; }
    }

    public class BUIBFormDefinition<TEntity> : BUIFormDefinition<TEntity>, IBUIBFormDefinition
    {
        public GridColumnSpan LabelColumnSpan { get; set; } = GridColumnSpan.Three;
        public GridColumnSpan InputColumnSpan { get; set; } = GridColumnSpan.Nine;
    }

    public partial class BUIBForm<TEntity, TFormDefinition> : BUIForm<TEntity, TFormDefinition>
        where TFormDefinition : BUIFormDefinition<TEntity>, new()
    { }


    public abstract class BUIBFormElement<TValue> : BUIFormElement<TValue>
    {
        public string IsInvalidCssClass => IsModified && ValidationMessages.Any() ? "is-invalid" : string.Empty;

        [CascadingParameter]
        public IBUIBFormDefinition FormDefinition { get; set; }
    }

}
