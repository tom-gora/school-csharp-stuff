using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace BatmanDataContext {
  public class BatmanDb : DbContext {
    public DbSet<BatmanFilm>? BatmanFilms { get; set; }
    public DbSet<BatmanActor>? BatmanActors { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=Resources/BatmanDatabase.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<BatmanFilm>().HasKey(m => m.FilmID);
      modelBuilder.Entity<BatmanActor>().HasKey(m => m.ActorID);
    }
  }

}