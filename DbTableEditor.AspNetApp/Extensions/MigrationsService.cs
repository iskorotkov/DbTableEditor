using DbTableEditor.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DbTableEditor.AspNetApp.Extensions
{
    public static class MigrationsService
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<SpaceshipsContext>();
            context.Database.Migrate();
            return host;
        }
    }
}
