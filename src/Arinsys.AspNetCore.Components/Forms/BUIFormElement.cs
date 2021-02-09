using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arinsys.AspNetCore.Components
{
    public abstract class BUIFormElement<TValue> : BaseComponent
    {
        [Parameter]
        public string Identifier { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Placeholder { get; set; }

        [Parameter]
        public TValue Value { get; set; }

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }

        protected async Task OnValueChanged(ChangeEventArgs eventArgs)
        {
            await ValueChanged.InvokeAsync((TValue)eventArgs.Value);
            CascadedEditContext.Validate();
        }

        [CascadingParameter]
        public EditContext CascadedEditContext { get; set; }

        public FieldIdentifier FieldIdentifier => CascadedEditContext.Field(Identifier);

        public bool IsModified => CascadedEditContext.IsModified(FieldIdentifier);

        public IEnumerable<string> ValidationMessages => CascadedEditContext.GetValidationMessages(FieldIdentifier);
    }
}
