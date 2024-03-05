using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace BatmanDataContext {
  //implementation via inheritance of default DbContext class provided with EFC
  public class BatmanDb : DbContext {
    public DbSet<BatmanFilm>? BatmanFilms { get; set; }
    public DbSet<BatmanActor>? BatmanActors { get; set; }
    // these methods override default methods coming with DbContext to ensure
    // mapping from DB to collection of objects is done properly
    // can decalre behaviors and configs like source and target types, names etc
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=Resources/BatmanDatabase.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<BatmanFilm>().HasKey(m => m.FilmID);
      modelBuilder.Entity<BatmanActor>().HasKey(m => m.ActorID);
    }
  }
}