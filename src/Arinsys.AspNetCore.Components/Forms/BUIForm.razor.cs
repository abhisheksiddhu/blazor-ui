using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Arinsys.AspNetCore.Components
{
    public interface IBUIFormDefinition
    {
        string FormIdentifierPrefix { get; set; }
    }

    public class BUIFormDefinition<TEntity> : IBUIFormDefinition
    {
        public string FormIdentifierPrefix { get; set; }
    }

    public partial class BUIForm<TEntity, TFormDefinition> : BaseComponent
        where TFormDefinition : BUIFormDefinition<TEntity>, new()
    {
        [Parameter]
        public EventCallback<EditContext> OnValidSubmit { get; set; }

        [Parameter]
        public EventCallback<EditContext> OnInvalidSubmit { get; set; }

        [Parameter]
        public virtual TEntity Data { get; set; }

        [Parameter]
        public RenderFragment<TEntity> ChildContent { get; set; }

        [Parameter]
        public RenderFragment Loading { get; set; }

        [Parameter]
        public TFormDefinition Definition { get; set; } = new();
    }
}
