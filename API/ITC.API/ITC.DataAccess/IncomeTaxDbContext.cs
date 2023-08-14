using ITC.DataAccess.Entities;
using ITC.DataAccess.Utils;
using Microsoft.EntityFrameworkCore;
using System;

namespace ITC.DataAccess
{
    public class IncomeTaxDbContext : DbContext
    {
        public IncomeTaxDbContext(DbContextOptions<IncomeTaxDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxBand>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(x => x.CreationDate)
                    .HasDefaultValueSql(Constants.DbGetDateFunction)
                    .HasColumnType(Constants.DefaultDateType);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.EnumStringMaxLength);

                entity.Property(x => x.LowerLimit)
                    .IsRequired();

                entity.Property(x => x.UpperLimit)
                    .IsRequired(false);

                entity.Property(x => x.Rate)
                    .IsRequired();
            });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxBand>(entity =>
                entity.HasData(
                     new TaxBand
                     {
                         Id = Guid.Parse("dcb1ab88-d3c3-4022-bb75-cc9ef852202d"),
                         Name = "Band 1",
                         UpperLimit = 5000,
                         LowerLimit = 0,
                         Rate = 0
                     },
                     new TaxBand
                     {
                         Id = Guid.Parse("63ebc360-2065-44a1-80a6-cafd42fba309"),
                         Name = "Band 2",
                         UpperLimit = 20000,
                         LowerLimit = 5000,
                         Rate = 20
                     },
                     new TaxBand
                     {
                         Id = Guid.Parse("72c3a4c3-65f6-44b9-93db-f52a841d4eea"),
                         Name = "Band 3",
                         UpperLimit = null,
                         LowerLimit = 20000,
                         Rate = 40
                     }));
        }
    }
}
