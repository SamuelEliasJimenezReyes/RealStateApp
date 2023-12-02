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

        public DbSet<PropertiesImprovents> PropertiesImprovents { get; set; }
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
            modelBuilder.Entity<PropertiesImprovents>().ToTable("PropertiesImprovents");
            modelBuilder.Entity<FavoriteProperties>().ToTable("FavoriteProperties");
            #endregion

            #region Primary keys
            modelBuilder.Entity<ImagesProperties>().HasKey(a => a.Id);
            modelBuilder.Entity<Improvements>().HasKey(a => a.Id);
            modelBuilder.Entity<Properties>().HasKey(a => a.Id);
            modelBuilder.Entity<PropertiesTypes>().HasKey(a => a.Id);
            modelBuilder.Entity<SalesTypes>().HasKey(a => a.Id);
            modelBuilder.Entity<PropertiesImprovents>().HasKey(a => new {a.PropertiesId, a.ImproventId});
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

            modelBuilder.Entity<PropertiesImprovents>()
                .HasOne(a => a.Properties)
                .WithMany(a => a.PropertiesImprovents)
                .HasForeignKey(a => a.PropertiesId);

            modelBuilder.Entity<PropertiesImprovents>()
                .HasOne(a => a.improvements)
                .WithMany(a => a.PropertiesImprovents)
                .HasForeignKey(a => a.ImproventId);

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




        }
    }
}
