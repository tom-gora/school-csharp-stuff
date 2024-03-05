using System;
using BatmanDataContext;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace BatmanLinq {
  class Program {
    static void Main(string[] args) {
      BatmanFilmsContext db = new BatmanFilmsContext();
      List<BatmanFilm>? films = db.BatmanFilms!.ToList();

      BatmanActorsContext db2 = new BatmanActorsContext();
      List<BatmanActor>? actors = db2.BatmanActors!.ToList();

      List<BatmanFilmsJoinedWithActors> joinedTables = db.BatmanFilms.Join(db2.BatmanActors,
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

// TODO: Who new you cannot perform joins on two distinct databases XD Bring in both tables into one DB tomorrow you dumb idiot tom XD