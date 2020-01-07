using CarSupplier.DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSupplier.DA.EFCore
{
    public class CarEngineEntityConfiguration : IEntityTypeConfiguration<CarEngineEntity>
    {
        public void Configure(EntityTypeBuilder<CarEngineEntity> builder)
        {
            builder.ToTable("CarEngine");

            builder.HasKey(x => new { x.Manufacturer, x.ModelNumber });

            builder.Property(x => x.Manufacturer).HasMaxLength(100);
            builder.Property(x => x.ModelNumber).HasMaxLength(20);
            builder.Property(x => x.FuelType);
            builder.Property(x => x.BHP);
        }
    }
}