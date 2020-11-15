using Arinsys.Components.AspNetCore.Bootstrap;

namespace Arinsys.Extensions
{
    public static class PanelExtensiona
    {
        public static string GetCategoryCssClass(this ElementStatusCategory category)
        {
            return category switch
            {
                ElementStatusCategory.Default => "panel-default",
                ElementStatusCategory.Info => "panel-info",
                ElementStatusCategory.Primary => "panel-primary",
                ElementStatusCategory.Success => "panel-success",
                ElementStatusCategory.Warning => "panel-warning",
                ElementStatusCategory.Danger => "panel-danger",
                _ => "panel-default",
            };
        }
    }
}
