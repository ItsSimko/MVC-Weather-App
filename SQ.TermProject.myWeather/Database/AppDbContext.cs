using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using SQ.TermProject.myWeather.Models;
using SQ.TermProject.myWeather.Services;
using System.Security.Cryptography.X509Certificates;

namespace SQ.TermProject.myWeather.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public DbSet<User>? Users {get; set;}
        public DbSet<UserRole> UserRoles {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "server=localhost;port=3306;database=WeatherApp;user=root;password=2025";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Salt).IsRequired();
                entity.Property(e => e.RoleId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.PermissionLevel).IsRequired();
            });




        }
    }
}

