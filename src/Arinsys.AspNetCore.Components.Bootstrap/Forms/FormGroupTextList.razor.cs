﻿using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arinsys.AspNetCore.Components.Bootstrap.Forms
{
    public partial class FormGroupTextList : BaseFormGroup<List<string>>
    {
        [Parameter]
        public List<string> Values { get; set; }

        [Parameter]
        public EventCallback<List<string>> ValuesChanged { get; set; }

        protected async Task OnValueChanged(ChangeEventArgs eventArgs, int index)
        {
            Values[index] = eventArgs.Value.ToString();
            await ValuesChanged.InvokeAsync(Values);
            CascadedEditContext.Validate();
        }

        protected async Task OnValueDeleted(int index)
        {
            Values.RemoveAt(index);
            await ValuesChanged.InvokeAsync(Values);
            CascadedEditContext.Validate();
        }

        protected async Task OnValueAdded()
        {
            Values.Add(string.Empty);
            await ValuesChanged.InvokeAsync(Values);
            CascadedEditContext.Validate();
        }
    }
}
