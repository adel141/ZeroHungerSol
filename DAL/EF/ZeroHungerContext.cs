using System;
using System.Collections.Generic;
using DAL.EF.Table;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public partial class ZeroHungerContext : DbContext
{
    public ZeroHungerContext()
    {
    }

    public ZeroHungerContext(DbContextOptions<ZeroHungerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<FoodCollectionRequest> FoodCollectionRequests { get; set; }

    public virtual DbSet<FoodItem> FoodItems { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.Property(e => e.AcceptedAt).HasColumnType("datetime");
            entity.Property(e => e.CollectedAt).HasColumnType("datetime");
            entity.Property(e => e.DistributedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignments_Employees");

            entity.HasOne(d => d.Request).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignments_FoodCollectionRequests");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FoodCollectionRequest>(entity =>
        {
            entity.Property(e => e.PreservationDeadline).HasColumnType("datetime");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Restaurant).WithMany(p => p.FoodCollectionRequests)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FoodCollectionRequests_Restaurants");
        });

        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.Property(e => e.FoodName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Request).WithMany(p => p.FoodItems)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FoodItems_FoodCollectionRequests");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RestaurantName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
