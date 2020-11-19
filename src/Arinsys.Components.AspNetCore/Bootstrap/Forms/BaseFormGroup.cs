using Microsoft.AspNetCore.Components;

namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public abstract class BaseFormGroup<TValue> : AspNetCore.BaseFormGroup<TValue>
    {
        [Parameter]
        public GridColumnSpan GridColumnSpan { get; set; } = GridColumnSpan.Auto;
    }
}
