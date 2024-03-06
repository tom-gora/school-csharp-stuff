
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace DataContext {
  public class SiteDataContext : DbContext {
    public DbSet<Site>? Sites { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=Resources/WorldWideWeb.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      // To avoid problems explicitly declare which column is the primary key
      modelBuilder.Entity<Site>().HasKey(m => m.ID);
      modelBuilder.Entity<Site>().ToTable("TopUKSites");

    }
  }
};