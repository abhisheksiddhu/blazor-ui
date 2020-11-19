using Microsoft.AspNetCore.Components.Forms;

using System.Collections.Generic;

namespace Arinsys.Components.AspNetCore
{
    public interface IBUI_FormGroup
    {
        string Identifier { get; set; }
        string Label { get; set; }
        string Placeholder { get; set; }
        EditContext CascadedEditContext { get; set; }
        FieldIdentifier FieldIdentifier { get; }
        bool IsModified { get; }
        IEnumerable<string> ValidationMessages { get; }
    }

    public interface IBUI_FormGroup<TValue> : IBUI_FormGroup
    {
    }
}