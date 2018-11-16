using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FleetManagementWebService.Models
{
    public partial class FleetDatabaseContext : DbContext
    {
        public FleetDatabaseContext()
        {

        }

        public FleetDatabaseContext(DbContextOptions<FleetDatabaseContext> options): base(options)
        {

        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<FleetTable> FleetTable { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<FleetTable>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateAcquired).HasColumnType("date");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.FleetTable)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Category");
            });
        }
    }
}
