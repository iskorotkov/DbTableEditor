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

        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var username = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME");
                var password = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD");
                optionsBuilder.UseNpgsql($"Host=localhost;Database=spaceships_auth;Username={username};Password={password}");
            }
        }
    }
}
