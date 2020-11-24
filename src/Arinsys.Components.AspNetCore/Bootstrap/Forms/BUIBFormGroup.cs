using Microsoft.AspNetCore.Components;

namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public abstract class BUIBFormGroup<TValue> : BUIFormGroup<TValue>
    {
        [Parameter]
        public GridColumnSpan GridColumnSpan { get; set; } = GridColumnSpan.Auto;
    }
}
