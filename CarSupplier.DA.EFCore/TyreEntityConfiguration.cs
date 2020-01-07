using CarSupplier.DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSupplier.DA.EFCore
{
    public class TyreEntityConfiguration : IEntityTypeConfiguration<TyreEntity>
    {
        public void Configure(EntityTypeBuilder<TyreEntity> builder)
        {
            builder.ToTable("Tyre");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}