using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Model;

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
        => optionsBuilder.UseSqlServer("Data Source=BDC11-L-2156S0P\\SQLEXPRESS01;Initial Catalog=FurnitureStoreDB;Integrated Security = True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4881EF6589C");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Username, "UQ__Admin__536C85E4DD4BCED9").IsUnique();

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BillingTable>(entity =>
        {
            entity.HasKey(e => e.BillingId).HasName("PK__BillingT__F1656DF3E195780C");

            entity.ToTable("BillingTable");

            entity.Property(e => e.BillingAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Customer).WithMany(p => p.BillingTables)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__BillingTa__Custo__02084FDA");

            entity.HasOne(d => d.OrderNumber).WithMany(p => p.BillingTables)
                .HasForeignKey(d => d.OrderNumberId)
                .HasConstraintName("FK__BillingTa__Order__02FC7413");
        });

        modelBuilder.Entity<CustomerMaster>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D879026D29");

            entity.ToTable("CustomerMaster");

            entity.HasIndex(e => e.Username, "UQ__Customer__536C85E47CDF05EE").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Displayname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FurnitureMaster>(entity =>
        {
            entity.HasKey(e => e.FurnitureId).HasName("PK__Furnitur__D4323525910C0F1E");

            entity.ToTable("FurnitureMaster");

            entity.Property(e => e.Detail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FurnitureName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
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
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF799A076E");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FurnitureName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__7C4F7684");

            entity.HasOne(d => d.Furniture).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FurnitureId)
                .HasConstraintName("FK__Orders__Furnitur__7B5B524B");

            entity.HasOne(d => d.OrderNumber).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderNumberId)
                .HasConstraintName("FK__Orders__OrderNum__7D439ABD");
        });

        modelBuilder.Entity<OrderNumber>(entity =>
        {
            entity.HasKey(e => e.OrderNumberId).HasName("PK__OrderNum__E6D543C9557E2253");

            entity.ToTable("OrderNumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
