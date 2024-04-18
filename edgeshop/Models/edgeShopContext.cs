using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace edgeshop.Models
{
    public partial class edgeShopContext : DbContext
    {
        public edgeShopContext()
        {
        }

        public edgeShopContext(DbContextOptions<edgeShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catagory> Catagories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-0U3KQS1; Database = edgeShop; Integrated Security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagory>(entity =>
            {
                entity.ToTable("Catagory");

                entity.Property(e => e.CatagoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CatagoryPicturePath)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ProductModel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPicturePath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnType("money");

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatagoryId)
                    .HasConstraintName("FK_Product_Catagory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
