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

        public DbSet<PropertiesTypes> PropertiesTypes { get; set; }

        public DbSet<SalesTypes> SaleTypes { get; set; }

        public DbSet<PropertiesImprovements> PropertiesImprovementss { get; set; }
        public DbSet<FavoriteProperties> FavoriteProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api

            #region tables

            modelBuilder.Entity<ImagesProperties>().ToTable("ImagesProperties");
            modelBuilder.Entity<Improvements>().ToTable("Improvements");
            modelBuilder.Entity<Properties>().ToTable("Properties");
            modelBuilder.Entity<PropertiesTypes>().ToTable("PropertiesTypes");
            modelBuilder.Entity<SalesTypes>().ToTable("SaleTypes");
            modelBuilder.Entity<PropertiesImprovements>().ToTable("PropertiesImprovementss");
            modelBuilder.Entity<FavoriteProperties>().ToTable("FavoriteProperties");
            #endregion

            #region Primary keys
            modelBuilder.Entity<ImagesProperties>().HasKey(a => a.Id);
            modelBuilder.Entity<Improvements>().HasKey(a => a.Id);
            modelBuilder.Entity<Properties>().HasKey(a => a.Id);
            modelBuilder.Entity<PropertiesTypes>().HasKey(a => a.Id);
            modelBuilder.Entity<SalesTypes>().HasKey(a => a.Id);
            modelBuilder.Entity<PropertiesImprovements>().HasKey(a => new {a.PropertiesId, a.ImprovementId});
            modelBuilder.Entity<FavoriteProperties>().HasKey(a => new { a.PropertiesId, a.ClientId });
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
                .HasOne(a => a.PropertiesTypes)
                .WithMany(a => a.Properties)
                .HasForeignKey(a => a.PropertiesTypeId);

            modelBuilder.Entity<PropertiesImprovements>()
                .HasOne(a => a.Properties)
                .WithMany(a => a.PropertiesImprovements)
                .HasForeignKey(a => a.PropertiesId);

            modelBuilder.Entity<PropertiesImprovements>()
                .HasOne(a => a.Improvements)
                .WithMany(a => a.PropertiesImprovements)
                .HasForeignKey(a => a.ImprovementId);

            modelBuilder.Entity<FavoriteProperties>()
               .HasOne(a => a.Properties)
               .WithMany(a => a.FavoriteProperties)
               .HasForeignKey(a => a.PropertiesId);

            #endregion

            #region Querys
            modelBuilder.Entity<ImagesProperties>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Improvements>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Properties>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<PropertiesTypes>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<SalesTypes>().HasQueryFilter(x => !x.IsDeleted);
            #endregion

            #region DataInsertion

            #region Improvements
            modelBuilder.Entity<Improvements>()
                .HasData(new Improvements
                {
                    Id = 1,
                    Name = "Habitación",
                    Description = "es una habitación"
                    
                });

            modelBuilder.Entity<Improvements>()
             .HasData(new Improvements
             {
                 Id = 2,
                 Name = "Cocina",
                 Description = "es una Cocina"

             });
            #endregion

            #region PropertiesTypes
            modelBuilder.Entity<PropertiesTypes>()
                .HasData(new PropertiesTypes
                {
                    Id = 1,
                    Name = "Apartamento",
                    Description = "es una grasa"

                });
            #endregion

            #region SalesTypes
            modelBuilder.Entity<SalesTypes>()
                .HasData(new SalesTypes
                {
                    Id = 1,
                    Name = "Alquiler",
                    Description = "se paga en un determinado tiempo"

                });
            #endregion

            #endregion


        }
    }
}
