using Microsoft.JSInterop;

using System.Threading.Tasks;

namespace Arinsys.AspNetCore.Components.StateManagement
{
    public interface ICookieStorage
    {
        Task<string> GetCookie(string cookieName);
        Task SetCookie(string cookieName, string cookieValue, int expirySeconds);
    }

    public class CookieStorage : ICookieStorage
    {
        private readonly IJSRuntime jsRuntime;

        public CookieStorage(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        private ValueTask<IJSObjectReference> GetInteropModuleReference()
        {
            return jsRuntime.InvokeAsync<IJSObjectReference>("import", $"./{JsInterop.StaticAssetsPath}/js/interop.js");
        }

        public async Task<string> GetCookie(string cookieName)
        {
            IJSObjectReference interopModule = await GetInteropModuleReference();
            return await interopModule.InvokeAsync<string>("getCookie", cookieName);
        }

        public async Task SetCookie(string cookieName, string cookieValue, int expirySeconds)
        {
            IJSObjectReference interopModule = await GetInteropModuleReference();
            await interopModule.InvokeVoidAsync("setCookie", cookieName, cookieValue, expirySeconds);
        }
    }
}
