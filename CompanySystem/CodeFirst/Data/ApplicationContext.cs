using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<EmployeesProject> EmployeesProjects { get; set; }

        public DbSet<Dependent> Dependents { get; set; }

        public DbSet<Location> Locations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=ABDELMAGEED;Initial Catalog = CompanySystemCodeFirst;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dependent>().HasKey( k => new {k.SSN, k.DependentID});

            modelBuilder.Entity<EmployeesProject>().HasKey(k => new {k.SSN,k.PNum});

            modelBuilder.Entity<Location>().HasKey(k => new {k.DNum,k.LocationID});

            modelBuilder.Entity<Department>()
                .HasOne(e => e.Manager)
                .WithOne(d => d.Department)
                .HasForeignKey<Department>(fk => fk.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithOne(d => d.ManagedDepartment)
                .HasForeignKey(fk => fk.DNum)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.SuperSsnNavigation)
                .WithMany(d => d.InverseSuperSsnNavigation)
                .HasForeignKey(FK => FK.SuperSsn)
                .OnDelete(DeleteBehavior.Restrict);
                




        }


    }
}
