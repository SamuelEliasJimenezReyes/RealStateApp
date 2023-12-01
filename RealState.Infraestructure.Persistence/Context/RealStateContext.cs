using Microsoft.EntityFrameworkCore;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Context
{
    public  class RealStateContext : DbContext
    {
        public RealStateContext(DbContextOptions<RealStateContext> options) : base(options) { }


        public DbSet<ImagesProperties> ImagesProperties { get; set; }

        public DbSet<Improvements> Improvements { get; set; }

        public DbSet<Properties> Properties { get; set; }

        public DbSet<PropertyTypes> PropertyTypes { get; set; }

        public DbSet<SaleTypes> SaleTypes { get; set; }

        public DbSet<PropertyImprovents> PropertyImprovents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api

            #region tables

            modelBuilder.Entity<ImagesProperties>().ToTable("ImagesProperties");
            modelBuilder.Entity<Improvements>().ToTable("Improvements");
            modelBuilder.Entity<Properties>().ToTable("Properties");
            modelBuilder.Entity<PropertyTypes>().ToTable("PropertyTypes");
            modelBuilder.Entity<SaleTypes>().ToTable("SaleTypes");
            modelBuilder.Entity<PropertyImprovents>().ToTable("PropertyImprovents");

            #endregion

            #region Primary keys
            modelBuilder.Entity<ImagesProperties>().HasKey(a => a.Id);
            modelBuilder.Entity<Improvements>().HasKey(a => a.Id);
            modelBuilder.Entity<Properties>().HasKey(a => a.Id);
            modelBuilder.Entity<PropertyTypes>().HasKey(a => a.Id);
            modelBuilder.Entity<SaleTypes>().HasKey(a => a.Id);
            modelBuilder.Entity<PropertyImprovents>().HasKey(a => new {a.PropertyId, a.ImproventId});
            #endregion

            #region Relationships

            modelBuilder.Entity<ImagesProperties>()
                .HasOne(a => a.Properties)
                .WithMany(a => a.ImagesProperties)
                .HasForeignKey(a => a.PropertiesId);

            modelBuilder.Entity<Properties>()
               .HasOne(a => a.SaleType)
               .WithMany(a => a.Properties)
               .HasForeignKey(a => a.SaleTypeId);

             modelBuilder.Entity<Properties>()
                .HasOne(a => a.propertyTypes)
                .WithMany(a => a.Properties)
                .HasForeignKey(a => a.PropertyTypeId);

            modelBuilder.Entity<PropertyImprovents>()
                .HasOne(a => a.Properties)
                .WithMany(a => a.PropertyImprovents)
                .HasForeignKey(a => a.PropertyId);

            modelBuilder.Entity<PropertyImprovents>()
                .HasOne(a => a.improvements)
                .WithMany(a => a.PropertyImprovents)
                .HasForeignKey(a => a.ImproventId);


            #endregion

            #region Querys
            modelBuilder.Entity<ImagesProperties>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Improvements>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Properties>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<PropertyTypes>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<SaleTypes>().HasQueryFilter(x => !x.IsDeleted);
            #endregion 




        }
    }
}
