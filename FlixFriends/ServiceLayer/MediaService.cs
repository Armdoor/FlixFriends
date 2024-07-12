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

}