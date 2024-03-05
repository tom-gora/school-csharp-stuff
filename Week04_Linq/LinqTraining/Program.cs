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
        Console.WriteLine($"Film ID: {film.FilmID} Title: {film.FilmTitle}");
      }
      Console.WriteLine("\n-------------------- ACTORS:\n");
      foreach (BatmanActor actor in actors) {
        Console.WriteLine($"Actor ID: {actor.ActorID} Name: {actor.FirstName} {actor.LastName}");
      }
      Console.WriteLine("\n-------------------- JOINED DATA:\n");
      foreach (BatmanFilmsJoinedWithActors joinedTable in joinedTables) {
        Console.WriteLine($"Film ID: {joinedTable.FilmID} Title: {joinedTable.FilmTitle} Actor: {joinedTable.FirstName} {joinedTable.LastName}");
      }
    }
  }
}
