using Microsoft.AspNetCore.Components;

namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public abstract class BUIB_FormGroup<TValue> : BUI_FormGroup<TValue>
    {
        [Parameter]
        public GridColumnSpan GridColumnSpan { get; set; } = GridColumnSpan.Auto;
    }
}
