using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql;
using SQ.TermProject.myWeather.Models;
using SQ.TermProject.myWeather.Services;
using System.Security.Cryptography.X509Certificates;

namespace SQ.TermProject.myWeather.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User>? Users {get; set;}
        public DbSet<UserRole> UserRoles {get; set;}
        public DbSet<SearchStat> SearchStat {get; set;}
        public DbSet<Alert> Alerts {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigService.Configuration["DbConnection"];

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

            modelBuilder.Entity<SearchStat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Location).IsRequired();
                entity.Property(e => e.SearchCount).IsRequired();
            });

            modelBuilder.Entity<Alert>(entity =>
            {
                entity.HasKey(e => e.AlertId);
                entity.Property(e => e.AlertType);
                entity.Property(e => e.AlertMsg);
            });
        }
    }
}

