namespace FlixFriends.Models;

public class PopularMovies
{
    public int page { get; set; }
    public int total_results { get; set; }
    public int total_pages { get; set; }
    public List<PopularItemMovie> results { get; set; }
}

public class PopularItemMovie
{
    public bool adult { get; set; }
    public string backdrop_path { get; set; }
    public List<int> genre_ids { get; set; }
    public int id { get; set; }
    public string original_language { get; set; }
    public string original_title { get; set; }
    public string overview { get; set; }
    public double popularity { get; set; }
    public string poster_path { get; set; }
    public System.DateTime? release_date { get; set; }
    public string title { get; set; }
    public bool video { get; set; }
    public double vote_average { get; set; }
    public int vote_count { get; set; }
    public int? ReleaseYear => release_date?.Year;
    public string rated => (adult?"R":"PG");
}