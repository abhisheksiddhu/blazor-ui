using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using System;

namespace Arinsys.Components.AspNetCore
{
    public class FormDefinition<TEntity>
    {
        public Action<EventArgs, TEntity> OnSubmit { get; set; }
    }

    public partial class Form<TEntity, TFormDefinition> : BaseComponent
        where TFormDefinition : FormDefinition<TEntity>
    {
        [Parameter]
        public Action<EditContext, TEntity> OnValidSubmit { get; set; }

        [Parameter]
        public Action<EditContext, TEntity> OnInvalidSubmit { get; set; }

        [Parameter]
        public virtual TEntity Data { get; set; }

        [Parameter]
        public RenderFragment<TEntity> ChildContent { get; set; }

        [Parameter]
        public RenderFragment LoadingContent { get; set; }
    }
}
