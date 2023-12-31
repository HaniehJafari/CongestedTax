﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data
{
    public partial class FintranetContext : DbContext
    {
        public FintranetContext()
        {
        }

        public FintranetContext(DbContextOptions<FintranetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Models.MaximumDailyTax> MaximumDailyTax { get; set; }
        public virtual DbSet<Models.TollFees> TollFees { get; set; }
        public virtual DbSet<Models.TollFreeDates> TollFreeDates { get; set; }
        public virtual DbSet<Models.TollFreeVehicles> TollFreeVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Models.MaximumDailyTax>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Models.TollFees>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Models.TollFreeDates>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Models.TollFreeVehicles>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.VehicleType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}