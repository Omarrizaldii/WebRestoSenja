using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoffeSenja.API.Models;

public partial class CoffeSenjaContext : DbContext
{
    public CoffeSenjaContext()
    {
    }

    public CoffeSenjaContext(DbContextOptions<CoffeSenjaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DetailTransaction> DetailTransactions { get; set; }

    public virtual DbSet<HeaderTransaction> HeaderTransactions { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<PointHistory> PointHistories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS02;Database=CoffeSenja;Trusted_Connection=True;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PhotoPath)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetailTransaction>(entity =>
        {
            entity.ToTable("DetailTransaction");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.HeaderTransaction).WithMany(p => p.DetailTransactions)
                .HasForeignKey(d => d.HeaderTransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetailTransaction_HeaderTransaction1");

            entity.HasOne(d => d.Product).WithMany(p => p.DetailTransactions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetailTransaction_Product");
        });

        modelBuilder.Entity<HeaderTransaction>(entity =>
        {
            entity.ToTable("HeaderTransaction");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.HeaderTransactions)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HeaderTransaction_Customer");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.HeaderTransactions)
                .HasForeignKey(d => d.PaymentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HeaderTransaction_PaymentType");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.ToTable("PaymentType");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PointHistory>(entity =>
        {
            entity.ToTable("PointHistory");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.PointHistories)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PointHistory_Customer");

            entity.HasOne(d => d.HeaderTransaction).WithMany(p => p.PointHistories)
                .HasForeignKey(d => d.HeaderTransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PointHistory_HeaderTransaction");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ImageName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
