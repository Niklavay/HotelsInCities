using HotelsInCities.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.SQLConfigurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasMany(c => c.Hotels)
                   .WithOne(h => h.City)
                   .HasForeignKey(h => h.CityId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
