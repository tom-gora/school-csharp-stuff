using System;

namespace Entities {
  public class Album {
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public int ArtistId { get; set; }
  }

  public class Artist {
    public int ArtistId { get; set; }
    public string Name { get; set; }
  }

  public class AlbumWithArtistName {
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public int ArtistId { get; set; }
    public string ArtistName { get; set; }
  }

  public class Genre {
    public int GenreId { get; set; }
    public string Name { get; set; }
  }

  public class PlaylistTrack {
    public int PlaylistId { get; set; }
    public int TrackId { get; set; }

    // Navigation property for the associated playlist
    public Playlist Playlist { get; set; }

    // Navigation property for the associated track
    public Track Track { get; set; }
  }

  public class Playlist {
    public int PlaylistId { get; set; }
    public string Name { get; set; }
  }

  public class Track {
    public int TrackId { get; set; }
    public string Name { get; set; }
    public int AlbumId { get; set; }
    public int MediaTypeId { get; set; }
    public int GenreId { get; set; }
    public string Composer { get; set; }
    public int Milliseconds { get; set; }
    public int Bytes { get; set; }
    public decimal UnitPrice { get; set; }

    // Navigation property for the associated album
    public Album Album { get; set; }

    // Navigation property for the associated genre
    public Genre Genre { get; set; }

    // Navigation property for the associated media type
    public MediaType MediaType { get; set; }
  }

  public class MediaType {
    public int MediaTypeId { get; set; }
    public string Name { get; set; }
  }
}