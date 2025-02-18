using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace DataContext {
  public class EmployeeDataContext : DbContext {
    public DbSet<Employee>? Employees { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=Resources/chinook.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      // To avoid problems explicitly declare which column is the primary key
      modelBuilder.Entity<Employee>().HasKey(m => m.EmployeeId);
      modelBuilder.Entity<Employee>().ToTable("employees");
      modelBuilder.Entity<Employee>()
                     .Property(e => e.ReportsTo)
                     .HasDefaultValue(0);
    }
  }
}