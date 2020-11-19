using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using System.Collections.Generic;

namespace Arinsys.Components.AspNetCore
{
    public abstract class BUI_FormGroup<TValue> : BUI_Component, IBUI_FormGroup<TValue>
    {
        [Parameter]
        public string Identifier { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Placeholder { get; set; }

        [CascadingParameter]
        public EditContext CascadedEditContext { get; set; }

        public FieldIdentifier FieldIdentifier => CascadedEditContext.Field(Identifier);

        public bool IsModified => CascadedEditContext.IsModified(FieldIdentifier);

        public IEnumerable<string> ValidationMessages => CascadedEditContext.GetValidationMessages(FieldIdentifier);
    }
}
