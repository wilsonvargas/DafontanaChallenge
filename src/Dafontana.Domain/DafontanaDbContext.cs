using System;
using Dafontana.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dafontana.Domain
{
    public partial class DafontanaDbContext : DbContext
    {
        public DafontanaDbContext()
        {
        }

        public DafontanaDbContext(DbContextOptions<DafontanaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Store> Local { get; set; }
        public virtual DbSet<Trademark> Marca { get; set; }
        public virtual DbSet<Product> Producto { get; set; }
        public virtual DbSet<Sale> Venta { get; set; }
        public virtual DbSet<DetailSale> VentaDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Local__3E34B29DF6370FC0");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Trademark>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Marca__9B8F8DB2325A25B9");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Producto__9B4120E21FBD1C85");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.Model).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Trademark)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.TrademarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__ID_Mar__52593CB8");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Venta__3CD842E5A3F1C767");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.LocalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venta__ID_Local__571DF1D5");
            });

            modelBuilder.Entity<DetailSale>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__VentaDet__2F0CE38B52091CC3");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DetailSale)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VentaDeta__ID_Pr__5DCAEF64");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.DetailSale)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VentaDeta__ID_Ve__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
