using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace BatmanDataContext {
  public class BatmanFilmsContext : DbContext {
    public DbSet<BatmanFilm>? BatmanFilms { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=Resources/BatmanFilms.db");
    }
    // I DONT KNOW WHY AND I AM ANGRY AS HELL WHY IN THE TUTORIAL
    // TEACHER's DB WORKED WHEN IN REALITY ORM CRAPPED OUT NEEDING
    // BEING EXPLICITLY TOLD WHAT IS THE PRIMARY KEY ARGHHHH!
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<BatmanFilm>().HasKey(m => m.FilmID);
    }
  }

  public class BatmanActorsContext : DbContext {
    public DbSet<BatmanActor>? BatmanActors { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=Resources/BatmanActors.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<BatmanActor>().HasKey(m => m.ActorID);
      // }
    }
  }
}