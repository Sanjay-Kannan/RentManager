using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Models
{
    public partial class RentManagerContext : DbContext
    {
        public RentManagerContext()
        {
        }

        public RentManagerContext(DbContextOptions<RentManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Month> Months { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<Rent> Rents { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Tenant> Tenants { get; set; } = null!;
        public virtual DbSet<Year> Years { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.BillId).HasColumnName("Bill ID");

                entity.Property(e => e.BillAmounr)
                    .HasColumnType("money")
                    .HasColumnName("Bill Amounr");

                entity.Property(e => e.BillDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Bill description");

                entity.Property(e => e.MonthId).HasColumnName("Month ID");

                entity.Property(e => e.PropertyId).HasColumnName("Property ID");

                entity.Property(e => e.YearId).HasColumnName("Year ID");

                entity.HasOne(d => d.Month)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.MonthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_1_Month");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.BillsNavigation)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_1_Property");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_1_Year");
            });

            modelBuilder.Entity<Month>(entity =>
            {
                entity.ToTable("Month");

                entity.Property(e => e.MonthId).HasColumnName("Month ID");

                entity.Property(e => e.MonthName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Month Name");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.PropertyId).HasColumnName("Property Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("Rent");

                entity.Property(e => e.PaymentId).HasColumnName("Payment ID");

                entity.Property(e => e.BillId).HasColumnName("Bill ID");

                entity.Property(e => e.MonthId).HasColumnName("Month ID");

                entity.Property(e => e.RentPaid)
                    .HasColumnType("money")
                    .HasColumnName("Rent Paid");

                entity.Property(e => e.TenantId).HasColumnName("Tenant ID");

                entity.Property(e => e.TotalBill)
                    .HasColumnType("money")
                    .HasColumnName("Total Bill");

                entity.Property(e => e.YearId).HasColumnName("Year ID");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rent_Table_1");

                entity.HasOne(d => d.Month)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.MonthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rent_Month");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rent_Tenant");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rent_Year");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("Room ID");

                entity.Property(e => e.Deleted)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fixtures)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyId).HasColumnName("Property ID");

                entity.Property(e => e.RoomNumber).HasColumnName("Room Number");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_Property");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.ToTable("Tenant");

                entity.Property(e => e.TenantId).HasColumnName("Tenant ID");

                entity.Property(e => e.Advance).HasColumnType("money");

                entity.Property(e => e.AgreementInitiation)
                    .HasColumnType("date")
                    .HasColumnName("Agreement initiation");

                entity.Property(e => e.AgreementTermination)
                    .HasColumnType("date")
                    .HasColumnName("Agreement termination");

                entity.Property(e => e.ContactNumber).HasColumnName("Contact Number");

                entity.Property(e => e.Deleted)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Rent).HasColumnType("money");

                entity.Property(e => e.RoomId).HasColumnName("Room ID");

                entity.Property(e => e.TenantName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tenant Name");

                entity.Property(e => e.WaterAndMaintenance)
                    .HasColumnType("money")
                    .HasColumnName("Water and Maintenance");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Tenants)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tenant_Rooms");
            });

            modelBuilder.Entity<Year>(entity =>
            {
                entity.ToTable("Year");

                entity.Property(e => e.YearId).HasColumnName("Year ID");

                entity.Property(e => e.Year1).HasColumnName("Year");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
