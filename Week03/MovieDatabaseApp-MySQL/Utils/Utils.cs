using DataOperations;
using MovieEntity;

// utils collection for handling my retrieved data
namespace UtilsCollection {
  public static class Utils {

    // returns a random movie
    public static Movie GetRandomMovie() {
      Random rnd = new Random();
      using (var db = new MovieDbContext()) {
        var movies = db.Movies?.ToList();
        if (movies != null && movies.Count > 0) {
          return movies[rnd.Next(0, movies.Count)];
        }
        throw new InvalidOperationException("No movies found in the database.");
      }
    }

    // prints movie details
    public static void PrintRandomMovie(Movie m) {
      Console.WriteLine("Random movie data:\n");
      Console.WriteLine($"Movie ID: {m.movie_id}");
      Console.WriteLine($"Title: {m.title}");
      Console.WriteLine($"Director: {m.director}");
      Console.WriteLine($"Genre: {m.genre}");
      Console.WriteLine($"Release date:" +
          $"{Convert.ToDateTime(m.release_date).ToShortDateString()}");
      Console.WriteLine($"Language: {m.language}");
      Console.WriteLine($"Movie duration: {m.movie_duration}");
      Console.WriteLine($"Summary: {m.summary}");
    }
  }
}