using DbTableEditor.Auth.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DbTableEditor.Auth.Context
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var username = Environment.GetEnvironmentVariable("PGUSER");
                var password = Environment.GetEnvironmentVariable("PGPASSWORD");
                optionsBuilder.UseNpgsql($"Host=localhost;Database=spaceships_auth;Username={username};Password={password}",
                    options => options.MigrationsAssembly("DbTableEditor.Api"));
            }
        }
    }
}
