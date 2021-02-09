namespace Arinsys.AspNetCore.Components.Bootstrap
{
    public static class EnumExtensions
    {
        public static string GetCssClass(this GridColumnSpan gridColumnSpan)
        {
            return gridColumnSpan == GridColumnSpan.Auto ? "col" : $"col-{(int)gridColumnSpan}";
        }
    }
}
