using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementServer.Models.Entities;

namespace RestaurantManagementServer.Data;

public partial class FinalTermContext : DbContext
{
    public FinalTermContext()
    {
    }

    public FinalTermContext(DbContextOptions<FinalTermContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KIROLAPTOP\\SQLEXPRESS01;Database=FinalTerm;Trusted_connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__BRANCH__766E0D238E2EAE97");

            entity.ToTable("BRANCH");

            entity.Property(e => e.BranchId).HasColumnName("BRANCH_ID");
            entity.Property(e => e.BranchAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BRANCH_ADDRESS");
            entity.Property(e => e.BranchName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BRANCH_NAME");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__CUSTOMER__1CE12D37A604D041");

            entity.ToTable("CUSTOMERS");

            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_NAME");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.CustomerDetailId).HasName("PK__CUSTOMER__9A908FFEB60EFC0D");

            entity.ToTable("CUSTOMER_DETAILS");

            entity.Property(e => e.CustomerDetailId).HasColumnName("CUSTOMER_DETAIL_ID");
            entity.Property(e => e.CustomerBudget)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("CUSTOMER_BUDGET");
            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CUSTOMER___CUSTO__5441852A");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__ORDERS__460A946417B9EF7E");

            entity.ToTable("ORDERS");

            entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");
            entity.Property(e => e.BranchId).HasColumnName("BRANCH_ID");
            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.Ispayment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ISPAYMENT");
            entity.Property(e => e.Isship)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ISSHIP");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("ORDER_DATE");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PAYMENT_METHOD");
            entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");
            entity.Property(e => e.SeatId).HasColumnName("SEAT_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.HasOne(d => d.Branch).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__ORDERS__BRANCH_I__4D94879B");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__ORDERS__CUSTOMER__4AB81AF0");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ORDERS__PRODUCT___4BAC3F29");

            entity.HasOne(d => d.Seat).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SeatId)
                .HasConstraintName("FK__ORDERS__SEAT_ID__4CA06362");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId).HasName("PK__ORDER_DE__4DAAE6F08F9E6DFF");

            entity.ToTable("ORDER_DETAILS");

            entity.Property(e => e.OrderDetailsId).HasColumnName("ORDER_DETAILS_ID");
            entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__ORDER_DET__ORDER__571DF1D5");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__PRODUCTS__52B4176357945866");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__SEATS__79B89923B95A5B97");

            entity.ToTable("SEATS");

            entity.Property(e => e.SeatId).HasColumnName("SEAT_ID");
            entity.Property(e => e.BranchId).HasColumnName("BRANCH_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.HasOne(d => d.Branch).WithMany(p => p.Seats)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__SEATS__BRANCH_ID__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
