using HotelsInCities.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess
{
    public class HICDbContext : DbContext
    {
        public HICDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}