namespace MovieEntity {
  public class Movie {
    public int movie_id { get; set; }
    public string? title { get; set; }
    public string? director { get; set; }
    public string? genre { get; set; }
    public DateTime? release_date { get; set; }
    public string? language { get; set; }
    public TimeSpan movie_duration { get; set; }
    public string? summary { get; set; }
    public string? movie_link { get; set; }
  }
}