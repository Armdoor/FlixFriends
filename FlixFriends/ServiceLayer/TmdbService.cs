using FlixFriends.Data;
using FlixFriends.Interfaces;
using FlixFriends.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FlixFriends.ServiceLayer
{
    public class TmdbService : ITmdbService
    {
        private readonly string _apiKey ;
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _dbContext;

        public TmdbService(HttpClient httpClient, ApplicationDbContext dbContext,IConfiguration config)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _dbContext = dbContext;
            _apiKey = config["apiKey"];
        }

        public async Task<object?> GetMovieTmdb(string name)
        {
            var url = new Uri($"search/movie?query={name}&api_key={_apiKey}&page=1", UriKind.Relative);
            var response = await _httpClient.GetStringAsync(url);
            var searchResult = JsonConvert.DeserializeObject<SearchResult>(response);
    
            return searchResult;
        }
        
        public async Task<object?> GetMovieDetails(int movieId)
        {
            var url = new Uri($"movie/{movieId}?api_key={_apiKey}&append_to_response=credits", UriKind.Relative);
            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);
            var movieDetails = JsonConvert.DeserializeObject<MovieDetails>(response);
            // var productionCompanies = json["production_companies"].ToObject<List<ProductionCompany>>();
            // var productionCountries = json["production_countries"].ToObject<List<ProductionCountry>>();
            if (movieDetails != null)
            {
                movieDetails.VoteAverage = Math.Round(movieDetails.VoteAverage, 1);
                movieDetails.Popularity = Math.Round(movieDetails.Popularity, 1);
                // Add more adjustments here as needed
            }

            return movieDetails;
        }
        
        
        // Popular movies 
        public async Task<object?> GetPopularMovies()
        {
            var url = new Uri($"discover/movie?api_key={_apiKey}&page=1&sort_by=popularity.desc", UriKind.Relative);
            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);
            var results = json["results"].ToObject<List<PopularItemMovie>>();
            var popularMovies = new PopularMovies
            {
                page = (int)json["page"],
                total_results = (int)json["total_results"],
                total_pages = (int)json["total_pages"],
                results = results
            };
            foreach (var item in popularMovies.results)
            {
                item.vote_average = Math.Round(item.vote_average, 1);
                item.popularity = Math.Round(item.popularity, 1);
                // item.ReleaseYear = item.release_date?.Year;
            }
            return popularMovies;
        }
        
        public async Task<object?> GetTvTmdb(string name)
        {
            var url = new Uri($"search/tv?query={name}&api_key={_apiKey}&page=1", UriKind.Relative);
            var response = await _httpClient.GetStringAsync(url);
            Console.WriteLine(response);
            var json = JObject.Parse(response);
            return json;
        }
        
        public async Task<JObject?> GetTvDetails(int tvId)
        {
            var url = new Uri($"tv/{tvId}?api_key={_apiKey}", UriKind.Relative);
            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);
            return json;
        }
        
        public async Task<object?> GetPopularTv()
        {
            var url = new Uri($"discover/tv?api_key={_apiKey}&page=1&sort_by=popularity.desc", UriKind.Relative);
            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);

            // Extract and map results to List<PopularItemTv>
            var results = json["results"].ToObject<List<PopularItemTv>>();

            // Create PopularTv object
            var popularTv = new PopularTv
            {
                page = (int)json["page"],
                total_results = (int)json["total_results"],
                total_pages = (int)json["total_pages"],
                results = results
            };
            foreach (var item in popularTv.results)
            {
                item.vote_average = Math.Round(item.vote_average, 1);
                item.popularity = Math.Round(item.popularity, 1);
                // item.FirstAirYear = item.first_air_date?.Year;
            }

            return popularTv;
        }
    }
}