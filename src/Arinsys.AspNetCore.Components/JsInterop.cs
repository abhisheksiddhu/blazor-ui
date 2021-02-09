namespace Arinsys.AspNetCore.Components
{
    public static class JsInterop
    {
        static JsInterop()
        {
            AssemblyName = typeof(JsInterop).Module.Name.TrimEnd(".dll".ToCharArray());
            StaticAssetsPath = $"_content/{AssemblyName}";
        }

        public static string AssemblyName { get; }
        public static string StaticAssetsPath { get; }
    }
}
