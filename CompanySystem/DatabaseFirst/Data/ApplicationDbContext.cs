using System;
using System.Collections.Generic;
using DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Dependent> Dependents { get; set; }

    public virtual DbSet<EmoloyeesProject> EmoloyeesProjects { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ABDELMAGEED; Initial Catalog= CompanySystemDatabaseFirst;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Dnum).HasName("PK__Departme__24BF77575872A8B9");

            entity.Property(e => e.Dnum)
                .ValueGeneratedNever()
                .HasColumnName("DNUM");
            entity.Property(e => e.Dname)
                .HasMaxLength(50)
                .HasColumnName("DName");

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_ManagerID_Departments_To_Employees_SSN");
        });

        modelBuilder.Entity<Dependent>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeSsn, e.DependentId }).HasName("CompositPK");

            entity.Property(e => e.EmployeeSsn).HasColumnName("EmployeeSSN");
            entity.Property(e => e.DependentId)
                .HasMaxLength(50)
                .HasColumnName("DependentID");
            entity.Property(e => e.DependentName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(1);

            entity.HasOne(d => d.EmployeeSsnNavigation).WithMany(p => p.Dependents)
                .HasForeignKey(d => d.EmployeeSsn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSSN_Dependents_TO_Employees_SSN");
        });

        modelBuilder.Entity<EmoloyeesProject>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeSsn, e.ProjectNum }).HasName("CompositePK");

            entity.Property(e => e.EmployeeSsn).HasColumnName("EmployeeSSN");
            entity.Property(e => e.WorkingHours).HasColumnName("workingHours");

            entity.HasOne(d => d.EmployeeSsnNavigation).WithMany(p => p.EmoloyeesProjects)
                .HasForeignKey(d => d.EmployeeSsn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSSN_EmoloyeesProjects_To_Employess_SSN");

            entity.HasOne(d => d.ProjectNumNavigation).WithMany(p => p.EmoloyeesProjects)
                .HasForeignKey(d => d.ProjectNum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectNum_EmoloyeesProjects_To_Projects_PNum");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Ssn).HasName("PK__Employee__CA1E8E3DF14FF497");

            entity.Property(e => e.Ssn)
                .ValueGeneratedNever()
                .HasColumnName("SSN");
            entity.Property(e => e.Dnum).HasColumnName("DNUM");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("FName");
            entity.Property(e => e.Gender).HasMaxLength(1);
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("LName");
            entity.Property(e => e.SuperSsn).HasColumnName("SuperSSN");

            entity.HasOne(d => d.DnumNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Dnum)
                .HasConstraintName("FK_DNUM_Employees_To_Departments_DNUM");

            entity.HasOne(d => d.SuperSsnNavigation).WithMany(p => p.InverseSuperSsnNavigation)
                .HasForeignKey(d => d.SuperSsn)
                .HasConstraintName("SuperSSN_FK_TO_SNN");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => new { e.Dnum, e.LocationId }).HasName("Locations_CompositeKey");

            entity.Property(e => e.Dnum).HasColumnName("DNUM");
            entity.Property(e => e.LocationId).HasColumnName("LOcationID");
            entity.Property(e => e.Location1)
                .HasMaxLength(50)
                .HasColumnName("LOcation");

            entity.HasOne(d => d.DnumNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.Dnum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DNUM_Locations_To_Departments_DNUM");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Pnum).HasName("PK__Projects__5F42139F622C7EDE");

            entity.Property(e => e.Pnum)
                .ValueGeneratedNever()
                .HasColumnName("PNum");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Dnum).HasColumnName("DNUM");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Pname)
                .HasMaxLength(50)
                .HasColumnName("PName");

            entity.HasOne(d => d.DnumNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.Dnum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DNUM_Projects_To_DNUM_Departments");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
