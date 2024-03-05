using System;

namespace Entities {
  public class BatmanActor {
    public int? ActorID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
  }

  public class BatmanFilm {
    public int? FilmID { get; set; }
    public string? FilmTitle { get; set; }
    public int ReleaseYear { get; set; }
    public int? ActorID { get; set; }
  }

  public class BatmanFilmsJoinedWithActors {
    public int? FilmID { get; set; }
    public string? FilmTitle { get; set; }
    public int ReleaseYear { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
  }
}