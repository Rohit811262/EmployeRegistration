using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository.DBEntities;

public partial class EmployeRegistrationTestDbContext : DbContext
{
    IConfiguration _configuration;
    readonly string constr = "DefaultConnection";
    public EmployeRegistrationTestDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public virtual DbSet<EmployeInfo> EmployeInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString(constr));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeInfo>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__EmployeI__1299A861B88323C4");

            entity.ToTable("EmployeInfo");

            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emp_name");
            entity.Property(e => e.EmpWork)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emp_work");
            entity.Property(e => e.LastModified)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_modified");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
