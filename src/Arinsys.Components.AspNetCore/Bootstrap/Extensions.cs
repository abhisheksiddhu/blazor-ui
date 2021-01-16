namespace Arinsys.Components.AspNetCore.Bootstrap
{
    public static class EnumExtensions
    {
        public static string GetCssClass(this GridColumnSpan gridColumnSpan)
        {
            return gridColumnSpan == GridColumnSpan.Auto ? "col" : $"col-{(int)gridColumnSpan}";
        }
    }
}
