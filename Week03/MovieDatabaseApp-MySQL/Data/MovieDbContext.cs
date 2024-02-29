using Microsoft.EntityFrameworkCore;
using MovieEntity;
using Pomelo.EntityFrameworkCore.MySql;

namespace DataOperations {
  public class MovieDbContext : DbContext {
    public DbSet<Movie>? Movies { get; set; }

    protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder) {
      var password = Environment.GetEnvironmentVariable("WEBFLIX_PASS");
      // check against null
      if (!string.IsNullOrEmpty(password)) {
        string connection =
          "Server=151.236.217.189;"
          + "User ID=tomano_remote;"
          + $"Password={password};"
          + "Database=webflix_college_project";
        optionsBuilder
          .UseMySql(connection, ServerVersion.AutoDetect(connection));
      } else {
        // and hadle it if necessery
        throw new InvalidOperationException
          ("The password environment variable is not set or is incorrect.");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      // Specify the actual table name
      modelBuilder.Entity<Movie>().ToTable("webflix_movies");
      // Declare which column is the primary key
      modelBuilder.Entity<Movie>().HasKey(m => m.movie_id);
    }
  }
}