
using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace DataContext {
  public class AlbumsDataContext : DbContext {
    public DbSet<Album> Albums { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      // the part that the teacher mentioned
      // correct way to disable constraints check enforced by EntityFramework
      // even when there are none on the database itself
      optionsBuilder.UseSqlite("Data Source=Resources/chinook.db;foreign keys=false");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      // To avoid problems explicitly declare which column is the primary key
      modelBuilder.Entity<Album>().HasKey(m => m.AlbumId);
      modelBuilder.Entity<Album>().ToTable("albums");
    }
  }


  public class ArtistsDataContext : DbContext {
    public DbSet<Artist> Artists { get; set; }
    public int ArtistCount {
      get {
        return Artists.Count();
      }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=Resources/chinook.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      // To avoid problems explicitly declare which column is the primary key
      modelBuilder.Entity<Artist>().HasKey(m => m.ArtistId);
      modelBuilder.Entity<Artist>().ToTable("artists");
    }
  }

  public class AlbumsJoinedContext : DbContext {
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=Resources/chinook.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Album>().HasKey(m => m.AlbumId);
      modelBuilder.Entity<Album>().ToTable("albums");
      modelBuilder.Entity<Artist>().HasKey(m => m.ArtistId);
      modelBuilder.Entity<Artist>().ToTable("artists");
    }

    public List<AlbumWithArtistName> GetAlbumsWithArtistNames() {
      var albumsWithArtistNames = Albums
          .Join(Artists,
              album => album.ArtistId,
              artist => artist.ArtistId,
              (album, artist) => new AlbumWithArtistName {
                AlbumId = album.AlbumId,
                Title = album.Title,
                ArtistName = artist.Name
              })
          .ToList();

      return albumsWithArtistNames;
    }
  }

  public class PlaylistsContext : DbContext {
    public DbSet<Playlist>? Playlists { get; set; }
    public int PlaylistCount {
      get {
        return Playlists.Count();
      }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=Resources/chinook.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      // To avoid problems explicitly declare which column is the primary key
      modelBuilder.Entity<Playlist>().HasKey(m => m.PlaylistId);
      modelBuilder.Entity<Playlist>().ToTable("playlists");
    }
  }

  public class TracksContext : DbContext {
    public DbSet<Track>? Tracks { get; set; }
    public int TrackCount {
      get {
        return Tracks.Count();
      }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=Resources/chinook.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      // To avoid problems explicitly declare which column is the primary key
      modelBuilder.Entity<Track>().HasKey(m => m.TrackId);
      modelBuilder.Entity<Track>().ToTable("tracks");
    }
  }
}