using System;
using BatmanDataContext;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace BatmanLinq {
  class Program {
    static void Main(string[] args) {
      BatmanDb db = new BatmanDb();
      List<BatmanFilm>? films = db.BatmanFilms!.ToList();

      List<BatmanActor>? actors = db.BatmanActors!.ToList();

      List<BatmanFilmsJoinedWithActors>? joinedTables = db.BatmanFilms!.Join(db.BatmanActors!,
          film => film.ActorID, actor => actor.ActorID, (film, actor) => new BatmanFilmsJoinedWithActors() {
            FilmID = film.FilmID,
            FilmTitle = film.FilmTitle,
            ReleaseYear = film.ReleaseYear,
            FirstName = actor.FirstName,
            LastName = actor.LastName
          }
          ).ToList();

      Console.Clear();
      Console.WriteLine("Regular listing\n");
      Console.WriteLine("-------------------- FILMS:\n");
      foreach (BatmanFilm film in films) {
        if (film.FilmTitle.Length > 27) film.FilmTitle = film.FilmTitle.Substring(0, Math.Min(film.FilmTitle.Length, 27)) + "...";
        Console.WriteLine($"Film ID: {film.FilmID.ToString().PadRight(3)} Title: {film.FilmTitle.PadRight(30)} Release Year: {film.ReleaseYear.ToString()}");
      }
      Console.WriteLine("\n-------------------- ACTORS:\n");
      foreach (BatmanActor actor in actors) {
        Console.WriteLine($"Actor ID: {actor.ActorID.ToString().PadRight(3)} Name: {actor.FirstName} {actor.LastName}");
      }
      Console.WriteLine("\n-------------------- JOINED DATA:\n");
      foreach (BatmanFilmsJoinedWithActors joinedTable in joinedTables) {
        if (joinedTable.FilmTitle.Length > 27) joinedTable.FilmTitle = joinedTable.FilmTitle.Substring(0, Math.Min(joinedTable.FilmTitle.Length, 27)) + "...";
        Console.WriteLine($"Film ID: {joinedTable.FilmID.ToString().PadRight(3)} Title: {joinedTable.FilmTitle.PadRight(30)} Actor: {joinedTable.FirstName} {joinedTable.LastName}");
      }
    }
  }
}
