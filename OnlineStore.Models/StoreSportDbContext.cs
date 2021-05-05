using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnlineStore.Data.Config;
using OnlineStore.Data.Identity;
using OnlineStore.Data.Models;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineStore.Data
{
    public partial class StoreSportDbContext : IdentityDbContext<ApplicationUser>
    {
        public StoreSportDbContext()
        {
        }

        public StoreSportDbContext(DbContextOptions<StoreSportDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Frame> Frame { get; set; }
        public virtual DbSet<MuscleLoad> MuscleLoad { get; set; }
        public virtual DbSet<Padding> Padding { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductFrame> ProductFrame { get; set; }
        public virtual DbSet<ProductMuscleLoad> ProductMuscleLoad { get; set; }
        public virtual DbSet<ProductPadding> ProductPadding { get; set; }
        public virtual DbSet<ProductTexture> ProductTexture { get; set; }
        public virtual DbSet<Texture> Texture { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; initial catalog=OnlineStoreAspCore; integrated security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedRoles();
            modelBuilder.Entity<ProductFrame>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.FrameId });

                entity.HasOne(d => d.Frame)
                    .WithMany(p => p.ProductFrame)
                    .HasForeignKey(d => d.FrameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductFrame_Frame");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductFrame)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductFrame_Product");
            });

            modelBuilder.Entity<ProductMuscleLoad>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.MuscleLoadId });

                entity.HasOne(d => d.MuscleLoad)
                    .WithMany(p => p.ProductMuscleLoad)
                    .HasForeignKey(d => d.MuscleLoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductMuscleLoad_MuscleLoad");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductMuscleLoad)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductMuscleLoad_Product1");
            });

            modelBuilder.Entity<ProductPadding>(entity =>
            {
                entity.HasKey(e => new { e.PaddingId, e.ProductId });

                entity.HasOne(d => d.Padding)
                    .WithMany(p => p.ProductPadding)
                    .HasForeignKey(d => d.PaddingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPadding_Padding");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPadding)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPadding_Product");
            });

            modelBuilder.Entity<ProductTexture>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.TextureId });

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTexture)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductTexture_Product");

                entity.HasOne(d => d.Texture)
                    .WithMany(p => p.ProductTexture)
                    .HasForeignKey(d => d.TextureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductTexture_Texture");
            });

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
