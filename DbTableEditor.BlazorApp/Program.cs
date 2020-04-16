using DbTableEditor.BlazorApp.Services;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using DbTableEditor.BlazorApp.Services.Auth;
using DbTableEditor.BlazorApp.Services.Navigation;
using DbTableEditor.BlazorApp.Services.Saving;

namespace DbTableEditor.BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<ISaveOnCloseService, NoSaveOnClose>();
            builder.Services.AddSingleton<NavStack>();

            builder.Services.AddScoped<JwtAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
                provider.GetRequiredService<JwtAuthenticationStateProvider>());
            builder.Services.AddScoped<ILoginService>(provider =>
                provider.GetRequiredService<JwtAuthenticationStateProvider>());

            await builder.Build().RunAsync();
        }
    }
}
