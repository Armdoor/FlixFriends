using FlixFriends.Models;

namespace FlixFriends.Interfaces;

public interface IMediaService
{
    Task<object?> GetMediaAsync(string title);
    // Task<IEnumerable<Movies>> SearchMoviesAsync(string query);
}