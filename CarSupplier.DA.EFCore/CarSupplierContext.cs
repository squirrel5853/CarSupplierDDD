using CarSupplier.DA.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarSupplier.DA.EFCore
{
    public class CarSupplierContext : DbContext
    {
        public CarSupplierContext() : base()
        {

        }

        public CarSupplierContext(DbContextOptions<CarSupplierContext> options) : base(options)
        { 
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TyreEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CarEngineEntityConfiguration());

            //modelBuilder.Entity<WheelEntity>().ToTable("Wheel");
            //modelBuilder.Entity<CarFrameEntity>().ToTable("CarFrame");
            //modelBuilder.Entity<CarPaintEntity>().ToTable("CarPaint");
        }


        public DbSet<TyreEntity> Tyres { get; set; }

        public DbSet<WheelEntity> Wheels { get; set; }

        //public DbSet<CarFrameEntity> CarFrames { get; set; }

        public DbSet<CarEngineEntity> CarEngines { get; set; }

        public DbSet<CarPaintEntity> Paints { get; set; }
    }
}
