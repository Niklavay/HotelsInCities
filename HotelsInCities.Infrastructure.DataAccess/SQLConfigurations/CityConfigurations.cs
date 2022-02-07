using Core;
using HotelsInCities.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQLConfigurations
{
    public class CityConfigurations : IEntityTypeConfiguration<City>
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
