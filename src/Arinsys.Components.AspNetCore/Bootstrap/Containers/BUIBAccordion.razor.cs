using Microsoft.AspNetCore.Components;

using System.Collections.ObjectModel;

namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public partial class BUIBAccordion
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        internal ObservableCollection<BUIBAccordionTab> Tabs { get; set; } = new();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ChangeStateOn(Tabs);
        }
    }

    public class BUIBAccordionTab : BaseComponent
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
        public BUIBAccordion Accordion { get; set; }

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
