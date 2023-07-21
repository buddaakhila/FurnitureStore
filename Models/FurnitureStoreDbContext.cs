using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Models;

public partial class FurnitureStoreDbContext : DbContext
{
    public FurnitureStoreDbContext()
    {
    }

    public FurnitureStoreDbContext(DbContextOptions<FurnitureStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<BillingTable> BillingTables { get; set; }

    public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }

    public virtual DbSet<FurnitureMaster> FurnitureMasters { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderNumber> OrderNumbers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FurnitureStoreDB;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE488AB5CF295");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Username, "UQ__Admin__536C85E447F2FB79").IsUnique();

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BillingTable>(entity =>
        {
            entity.HasKey(e => e.BillingId).HasName("PK__BillingT__F1656DF321603DF7");

            entity.ToTable("BillingTable");

            entity.Property(e => e.BillingAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.BillingTables)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__BillingTa__Custo__40F9A68C");

            entity.HasOne(d => d.OrderNumber).WithMany(p => p.BillingTables)
                .HasForeignKey(d => d.OrderNumberId)
                .HasConstraintName("FK__BillingTa__Order__41EDCAC5");
        });

        modelBuilder.Entity<CustomerMaster>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8F05C383D");

            entity.ToTable("CustomerMaster");

            entity.HasIndex(e => e.Username, "UQ__Customer__536C85E40284BECF").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Displayname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FurnitureMaster>(entity =>
        {
            entity.HasKey(e => e.FurnitureId).HasName("PK__Furnitur__D4323525F3687883");

            entity.ToTable("FurnitureMaster");

            entity.Property(e => e.Detail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FurnitureName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Material)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF9BA8E724");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FurnitureName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__3B40CD36");

            entity.HasOne(d => d.Furniture).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FurnitureId)
                .HasConstraintName("FK__Orders__Furnitur__3A4CA8FD");

            entity.HasOne(d => d.OrderNumber).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderNumberId)
                .HasConstraintName("FK__Orders__OrderNum__3C34F16F");
        });

        modelBuilder.Entity<OrderNumber>(entity =>
        {
            entity.HasKey(e => e.OrderNumberId).HasName("PK__OrderNum__E6D543C99924A262");

            entity.ToTable("OrderNumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
