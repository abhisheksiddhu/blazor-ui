using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public partial class BUIB_Accordion
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        internal ObservableCollection<AccordionTab> Tabs { get; set; } = new();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ChangeStateOn(Tabs);
        }
    }

    public class AccordionTab : BaseComponent
    {
        [Parameter]
        public ElementStatusCategory Category { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public RenderFragment Body { get; set; }

        [Parameter]
        public bool IsCollapsed { get; set; } = true;

        [CascadingParameter]
        public BUIB_Accordion Accordion { get; set; }

        public void ToggleCollapse()
        {
            IsCollapsed = !IsCollapsed;
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Accordion.Tabs.Add(this);
        }

        protected override void Dispose(bool disposing)
        {
            Accordion.Tabs.Remove(this);
            base.Dispose(disposing);
        }
    }
}
