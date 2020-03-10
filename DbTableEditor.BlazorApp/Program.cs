using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DbTableEditor.Data.Context;
using DbTableEditor.BlazorApp.Data;

namespace DbTableEditor.BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddDbContext<SpaceshipsContext>();
            builder.Services.AddScoped<SpaceshipsProvider>();

            await builder.Build().RunAsync();
        }
    }
}
