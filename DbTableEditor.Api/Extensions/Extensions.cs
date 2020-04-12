using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DbTableEditor.Api.Extensions
{
    public static class Extensions
    {
        public static async Task ConfigureRoles(this IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new[] { "Editor", "Admin" };
            foreach (var role in roles)
            {
                if (await roleManager.RoleExistsAsync(role))
                {
                    continue;
                }

                var identityRole = new IdentityRole(role);
                await roleManager.CreateAsync(identityRole);
            }
        }
    }
}
