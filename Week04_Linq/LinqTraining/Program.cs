using System;
using BatmanDataContext;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace BatmanLinq {
  class Program {
    static void Main(string[] args) {
      BatmanDb db = new BatmanDb();
      //
      // getting rid of nullability warnings
      if (db.BatmanFilms == null || db.BatmanActors == null) {
        Console.WriteLine(
            "Error. Unable to read films and/or actors from database.");
        return;
      }

      List<BatmanFilm>? films = db.BatmanFilms!.ToList();

      List<BatmanActor>? actors = db.BatmanActors!.ToList();

      List<BatmanFilmsJoinedWithActors>? joinedList = db.BatmanFilms.Join(
          db.BatmanActors,
          film => film.ActorID, actor => actor.ActorID,
          (film, actor) => new BatmanFilmsJoinedWithActors() {
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
        // do null checks
        if (film.FilmID == null) film.FilmID = 0;
        if (film.FilmTitle == null) film.FilmTitle = "missing title";
        if (film.ReleaseYear == null) film.ReleaseYear = 0;
        if (film.ActorID == null) film.ActorID = 0;

        // preformat if title long
        if (film.FilmTitle.Length > 27) film.FilmTitle =
          film.FilmTitle.Substring(
              0,
              Math.Min(film.FilmTitle.Length, 27)) + "...";

        Console.WriteLine(
            $"Film ID: {film.FilmID.ToString()!.PadRight(3)} Title: {film.FilmTitle.PadRight(30)} Release Year: {film.ReleaseYear.ToString()}");
      }
      Console.WriteLine("\n-------------------- ACTORS:\n");
      foreach (BatmanActor actor in actors) {
        // do null checks
        if (actor.ActorID == null) actor.ActorID = 0;
        if (actor.FirstName == null) actor.FirstName = "missing first name";
        if (actor.LastName == null) actor.LastName = "missing last name";

        Console.WriteLine(
            $"Actor ID: {actor.ActorID.ToString()!.PadRight(3)} Name: {actor.FirstName} {actor.LastName}");
      }
      Console.WriteLine("\n-------------------- JOINED DATA:\n");
      foreach (BatmanFilmsJoinedWithActors joinedListItem in joinedList) {
        if (joinedListItem.FilmID == null) joinedListItem.FilmID = 0;
        if (joinedListItem.FilmTitle == null) joinedListItem.FilmTitle = "missing title";
        if (joinedListItem.ReleaseYear == null) joinedListItem.ReleaseYear = 0;
        if (joinedListItem.FirstName == null) joinedListItem.FirstName = "missing first name";
        if (joinedListItem.LastName == null) joinedListItem.LastName = "missing last name";

        // preformat if title long
        if (joinedListItem.FilmTitle.Length > 27) joinedListItem.FilmTitle =
          joinedListItem.FilmTitle.Substring(
              0, Math.Min(joinedListItem.FilmTitle.Length, 27)) + "...";

        Console.WriteLine(
            $"Film ID: {joinedListItem.FilmID.ToString()!.PadRight(3)} Title: {joinedListItem.FilmTitle.PadRight(30)} Actor: {joinedListItem.FirstName} {joinedListItem.LastName}");
      }
    }
  }
}