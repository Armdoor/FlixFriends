using Newtonsoft.Json.Linq;

namespace FlixFriends.Interfaces;

public interface ITmdbService
{
    Task<object?> GetMovieTmdb(string name);
    Task<object?> GetMovieDetails(int movieId);
    Task<object?> GetTvTmdb(string name);
    Task<JObject?> GetTvDetails(int tvId);
    Task<object?> GetPopularTv();
    Task<object?> GetPopularMovies();
}