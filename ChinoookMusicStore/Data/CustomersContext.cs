using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace DataContext {
  public class CustomersContext : DbContext {
    public DbSet<Customer>? Customers { get; set; }
    public int CustomerCount {
      get {
        return Customers.Count();
      }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=Resources/chinook.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      // To avoid problems explicitly declare which column is the primary key
      modelBuilder.Entity<Customer>().HasKey(m => m.CustomerId);
      modelBuilder.Entity<Customer>().ToTable("customers");
    }
  }
}