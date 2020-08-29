﻿using Microsoft.AspNetCore.Components;

using System.Threading.Tasks;

namespace Arinsys.Components.AspNetCore.Bootstrap.Forms
{
    public partial class FormGroupText : BaseFormGroup<string>
    {
        [Parameter]
        public string InputPrepend { get; set; }

        [Parameter]
        public string InputAppend { get; set; }

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        private async Task OnValueChanged(ChangeEventArgs eventArgs)
        {
            await ValueChanged.InvokeAsync(eventArgs.Value.ToString());
            CascadedEditContext.Validate();
        }
    }
}
