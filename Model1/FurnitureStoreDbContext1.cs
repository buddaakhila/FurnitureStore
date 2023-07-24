using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Model1;

public partial class FurnitureStoreDbContext1 : DbContext
{
    public FurnitureStoreDbContext1()
    {
    }

    public FurnitureStoreDbContext1(DbContextOptions<FurnitureStoreDbContext1> options)
        : base(options)
    {
    }

    public virtual DbSet<Allorder> Allorders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=BDC11-L-2156S0P\\SQLEXPRESS01;Initial Catalog=FurnitureStoreDB;Integrated Security = True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allorder>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("PK__allorder__080E377557BD97BD");

            entity.ToTable("allorders");

            entity.Property(e => e.Orderid)
                .ValueGeneratedNever()
                .HasColumnName("orderid");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.FurnitureName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
