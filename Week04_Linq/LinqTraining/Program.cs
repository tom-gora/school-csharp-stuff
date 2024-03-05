using System;
using System.Linq;
using BatmanDataContext;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace BatmanLinq {
  class Program {
    static void Main(string[] args) {
      BatmanDb db = new BatmanDb();
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

      Console.WriteLine("\n-------------------- ORDERED DATA (By actor's Last name):\n");
      List<BatmanFilmsJoinedWithActors>? orderedJoinedList = joinedList.OrderBy(actor => actor.LastName).ToList();
      foreach (BatmanFilmsJoinedWithActors orderedJoinedListItem in orderedJoinedList) {
        if (orderedJoinedListItem.FilmID == null) orderedJoinedListItem.FilmID = 0;
        if (orderedJoinedListItem.FilmTitle == null) orderedJoinedListItem.FilmTitle = "missing title";
        if (orderedJoinedListItem.ReleaseYear == null) orderedJoinedListItem.ReleaseYear = 0;
        if (orderedJoinedListItem.FirstName == null) orderedJoinedListItem.FirstName = "missing first name";
        if (orderedJoinedListItem.LastName == null) orderedJoinedListItem.LastName = "missing last name";

        // preformat if title long
        if (orderedJoinedListItem.FilmTitle.Length > 27) orderedJoinedListItem.FilmTitle =
          orderedJoinedListItem.FilmTitle.Substring(
              0, Math.Min(orderedJoinedListItem.FilmTitle.Length, 27)) + "...";

        Console.WriteLine(
            $"Film ID: {orderedJoinedListItem.FilmID.ToString()!.PadRight(3)} Title: {orderedJoinedListItem.FilmTitle.PadRight(30)} Actor: {orderedJoinedListItem.LastName} {orderedJoinedListItem.FirstName}");
      }

      Console.WriteLine("\n-------------------- ORDERED DATA (By film title descending):\n");
      orderedJoinedList = joinedList.OrderByDescending(film => film.FilmTitle).ToList();
      foreach (BatmanFilmsJoinedWithActors orderedJoinedListItem in orderedJoinedList) {
        if (orderedJoinedListItem.FilmID == null) orderedJoinedListItem.FilmID = 0;
        if (orderedJoinedListItem.FilmTitle == null) orderedJoinedListItem.FilmTitle = "missing title";
        if (orderedJoinedListItem.ReleaseYear == null) orderedJoinedListItem.ReleaseYear = 0;
        if (orderedJoinedListItem.FirstName == null) orderedJoinedListItem.FirstName = "missing first name";
        if (orderedJoinedListItem.LastName == null) orderedJoinedListItem.LastName = "missing last name";

        // preformat if title long
        if (orderedJoinedListItem.FilmTitle.Length > 27) orderedJoinedListItem.FilmTitle =
          orderedJoinedListItem.FilmTitle.Substring(
              0, Math.Min(orderedJoinedListItem.FilmTitle.Length, 27)) + "...";

        Console.WriteLine(
            $"Film ID: {orderedJoinedListItem.FilmID.ToString()!.PadRight(3)} Title: {orderedJoinedListItem.FilmTitle.PadRight(30)} Actor: {orderedJoinedListItem.LastName} {orderedJoinedListItem.FirstName}");
      }

      List<String>? filmTitlesOnly = db.BatmanFilms.Select(film => film.FilmTitle!).ToList();
      Console.WriteLine("\n-------------------- ONLY MOVIE TITLES IN ORDER:\n");
      for (int i = 0; i < filmTitlesOnly.Count; i++) {
        if (filmTitlesOnly[i] == null) filmTitlesOnly[i] = "missing title";
        Console.WriteLine(filmTitlesOnly[i]);
      }

      int startYear = 2000;
      int cutoffYear = 2010;
      List<BatmanFilm>? batmanFilmsFrom2000s = db.BatmanFilms.Where(film => film.ReleaseYear >= startYear && film.ReleaseYear <= cutoffYear).ToList();
      Console.WriteLine("\n-------------------- ONLY MOVIES RELEASED IN 2000s\n");
      foreach (BatmanFilm film in batmanFilmsFrom2000s) {
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
      Console.WriteLine("\n-------------------- FINALLY TRYING OUT RUNNING RAW SQL INSTEAD OF THE ABSTRACTION\n");
      using (BatmanDbRawSqlQueried dbRawSql = new BatmanDbRawSqlQueried()) {
        string q = "SELECT * FROM BatmanActors;";
        List<BatmanActor> rawQueriesActors = dbRawSql.ExecuteSql(q);
        foreach (BatmanActor actor in rawQueriesActors) {
          // do null checks
          if (actor.ActorID == null) actor.ActorID = 0;
          if (actor.FirstName == null) actor.FirstName = "missing first name";
          if (actor.LastName == null) actor.LastName = "missing last name";

          Console.WriteLine(
              $"Actor ID: {actor.ActorID.ToString()!.PadRight(3)} Name: {actor.FirstName} {actor.LastName}");
        }
      }
    }



  }
}

