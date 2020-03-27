using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace DbTableEditor.BlazorApp.Extensions
{
    public static class JSRuntimeExtensions
    {
        public static ValueTask SetInLocalStorage(this IJSRuntime js, string key, string value)
        {
            return js.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<string>("localStorage.getItem", key);
        }

        public static ValueTask RemoveFromLocalStorage(this IJSRuntime js, string key)
        {
            return js.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
