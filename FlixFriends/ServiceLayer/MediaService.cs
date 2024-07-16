using System.Text.Json.Nodes;
using FlixFriends.Data;
using FlixFriends.Interfaces;
using FlixFriends.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace FlixFriends.ServiceLayer;

public class MediaService: IMediaService
{
    private const string _apiKey = "8440313c";
    private readonly HttpClient _httpClient;
    private readonly ApplicationDbContext _dbContext;
    public MediaService(HttpClient httpClient, ApplicationDbContext dbContext)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://www.omdbapi.com/");
        _dbContext = dbContext;        
    }
    
    public async Task<object?> GetMediaAsync(string title)
    {
        var movie = await _dbContext.Movies.FirstOrDefaultAsync(m=>m.Title == title);
        if (movie != null) return movie;
        var series = await _dbContext.Series.FirstOrDefaultAsync(m=>m.Title == title);
        if (series != null) return series;
        
        var url = new Uri($"?t={title}&apikey={_apiKey}", UriKind.Relative);
        var response = await _httpClient.GetStringAsync(url);
        var json = JObject.Parse(response);
        
        
        if (json["Type"]?.ToString() == "series")
        {
            series = new Series
            {
                imdbID = json["imdbID"]?.ToString() ?? string.Empty,
                Title = json["Title"]?.ToString() ?? string.Empty,
                Year = json["Year"]?.ToString() ?? string.Empty,
                Rated = json["Rated"]?.ToString() ?? string.Empty,
                Released = json["Released"]?.ToString() ?? string.Empty,
                Runtime = json["Runtime"]?.ToString() ?? string.Empty,
                Genre = json["Genre"]?.ToString() ?? string.Empty,
                Director = json["Director"]?.ToString() ?? string.Empty,
                Writer = json["Writer"]?.ToString() ?? string.Empty,
                Actors = json["Actors"]?.ToString() ?? string.Empty,
                Plot = json["Plot"]?.ToString() ?? string.Empty,
                Language = json["Language"]?.ToString() ?? string.Empty,
                Country = json["Country"]?.ToString() ?? string.Empty,
                Awards = json["Awards"]?.ToString() ?? string.Empty,
                Poster = json["Poster"]?.ToString() ?? string.Empty,
                Metascore = json["Metascore"]?.ToString() ?? string.Empty,
                ImdbRating = json["imdbRating"]?.ToString() ?? string.Empty,
                ImdbVotes = json["imdbVotes"]?.ToString() ?? string.Empty,
                Type = json["Type"]?.ToString() ?? string.Empty,
                TotalSeasons = json["TotalSeasons"]?.ToString() ?? string.Empty,
                Response = json["Response"]?.ToString() ?? string.Empty
            };
            _dbContext.Series.Add(series);
            await _dbContext.SaveChangesAsync();
            return series;
        }
        else if (json["Type"]?.ToString() == "movie")
        {
            movie = new Movies
            {
                imdbID = json["imdbID"]?.ToString() ?? string.Empty,
                Title = json["Title"]?.ToString() ?? string.Empty,
                Year = json["Year"]?.ToString() ?? string.Empty,
                Rated = json["Rated"]?.ToString() ?? string.Empty,
                Released = json["Released"]?.ToString() ?? string.Empty,
                Runtime = json["Runtime"]?.ToString() ?? string.Empty,
                Genre = json["Genre"]?.ToString() ?? string.Empty,
                Director = json["Director"]?.ToString() ?? string.Empty,
                Writer = json["Writer"]?.ToString() ?? string.Empty,
                Actors = json["Actors"]?.ToString() ?? string.Empty,
                Plot = json["Plot"]?.ToString() ?? string.Empty,
                Language = json["Language"]?.ToString() ?? string.Empty,
                Country = json["Country"]?.ToString() ?? string.Empty,
                Awards = json["Awards"]?.ToString() ?? string.Empty,
                Poster = json["Poster"]?.ToString() ?? string.Empty,
                Metascore = json["Metascore"]?.ToString() ?? string.Empty,
                ImdbRating = json["imdbRating"]?.ToString() ?? string.Empty,
                ImdbVotes = json["imdbVotes"]?.ToString() ?? string.Empty,
                Type = json["Type"]?.ToString() ?? string.Empty,
                DVD = json["DVD"]?.ToString() ?? string.Empty,
                BoxOffice = json["BoxOffice"]?.ToString() ?? string.Empty,
                Production = json["Production"]?.ToString() ?? string.Empty,
                Website = json["Website"]?.ToString() ?? string.Empty,
                Response = json["Response"]?.ToString() ?? string.Empty
            };

            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();
            return movie;
        }
        
        
        return null;
    }
    public async Task<List<Movies>> GetTop20MoviesAsync()
        {
            var url = new Uri($"?s=&type=movie&apikey={_apiKey}&page=1"); // Modify URL to fetch movies
            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);

            var movies = json["Search"].Select(m => new Movies
            {
                imdbID = m["imdbID"]?.ToString() ?? string.Empty,
                Title = m["Title"]?.ToString() ?? string.Empty,
                Year = m["Year"]?.ToString() ?? string.Empty,
                Rated = m["Rated"]?.ToString() ?? string.Empty,
                Released = m["Released"]?.ToString() ?? string.Empty,
                Runtime = m["Runtime"]?.ToString() ?? string.Empty,
                Genre = m["Genre"]?.ToString() ?? string.Empty,
                Director = m["Director"]?.ToString() ?? string.Empty,
                Writer = m["Writer"]?.ToString() ?? string.Empty,
                Actors = m["Actors"]?.ToString() ?? string.Empty,
                Plot = m["Plot"]?.ToString() ?? string.Empty,
                Language = m["Language"]?.ToString() ?? string.Empty,
                Country = m["Country"]?.ToString() ?? string.Empty,
                Awards = m["Awards"]?.ToString() ?? string.Empty,
                Poster = m["Poster"]?.ToString() ?? string.Empty,
                Metascore = m["Metascore"]?.ToString() ?? string.Empty,
                ImdbRating = m["imdbRating"]?.ToString() ?? string.Empty,
                ImdbVotes = m["imdbVotes"]?.ToString() ?? string.Empty,
                Type = m["Type"]?.ToString() ?? string.Empty,
                DVD = m["DVD"]?.ToString() ?? string.Empty,
                BoxOffice = m["BoxOffice"]?.ToString() ?? string.Empty,
                Production = m["Production"]?.ToString() ?? string.Empty,
                Website = m["Website"]?.ToString() ?? string.Empty,
                Response = m["Response"]?.ToString() ?? string.Empty
            }).ToList();

            return movies;
        }

        public async Task<List<Series>> GetTop20ShowsAsync()
        {
            var url = new Uri($"?s=&type=series&apikey={_apiKey}&page=1"); // Modify URL to fetch series
            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);

            var series = json["Search"].Select(s => new Series
            {
                imdbID = s["imdbID"]?.ToString() ?? string.Empty,
                Title = s["Title"]?.ToString() ?? string.Empty,
                Year = s["Year"]?.ToString() ?? string.Empty,
                Rated = s["Rated"]?.ToString() ?? string.Empty,
                Released = s["Released"]?.ToString() ?? string.Empty,
                Runtime = s["Runtime"]?.ToString() ?? string.Empty,
                Genre = s["Genre"]?.ToString() ?? string.Empty,
                Director = s["Director"]?.ToString() ?? string.Empty,
                Writer = s["Writer"]?.ToString() ?? string.Empty,
                Actors = s["Actors"]?.ToString() ?? string.Empty,
                Plot = s["Plot"]?.ToString() ?? string.Empty,
                Language = s["Language"]?.ToString() ?? string.Empty,
                Country = s["Country"]?.ToString() ?? string.Empty,
                Awards = s["Awards"]?.ToString() ?? string.Empty,
                Poster = s["Poster"]?.ToString() ?? string.Empty,
                Metascore = s["Metascore"]?.ToString() ?? string.Empty,
                ImdbRating = s["imdbRating"]?.ToString() ?? string.Empty,
                ImdbVotes = s["imdbVotes"]?.ToString() ?? string.Empty,
                Type = s["Type"]?.ToString() ?? string.Empty,
                TotalSeasons = s["TotalSeasons"]?.ToString() ?? string.Empty,
                Response = s["Response"]?.ToString() ?? string.Empty
            }).ToList();

            return series;
        }

}
