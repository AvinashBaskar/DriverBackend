using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BEdotnetdrive.Models;

public partial class DriverdbContext : DbContext
{
    public DriverdbContext()
    {
    }

    public DriverdbContext(DbContextOptions<DriverdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driverapply> Driverapplies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ASTLPTWFH118\\SQLEXPRESS;Initial Catalog=driverdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driverapply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Driverap__3213E83F6257C6E1");

            entity.ToTable("Driverapply");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DriverAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LicenseNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.OwnorRent)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.WorkExperience)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
