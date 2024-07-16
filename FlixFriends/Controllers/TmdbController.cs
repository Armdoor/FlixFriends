using FlixFriends.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlixFriends.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TmdbController : ControllerBase
    {
        private readonly ITmdbService _tmdbService;

        public TmdbController(ITmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("search-movie")]
        public async Task<IActionResult> SearchMovie(string name)
        {
            var result = await _tmdbService.GetMovieTmdb(name);
            return Ok(result);
        }
        
        [HttpGet("details-movie/{id}")]
        public async Task<IActionResult> GetMovieDetails(int id)
        {
            var result = await _tmdbService.GetMovieDetails(id);
            return Ok(result);
        }
        
        [HttpGet("search-tv")]
        public async Task<IActionResult> SearchTv(string name)
        {
            var result = await _tmdbService.GetTvTmdb(name);
            return Ok(result);
        }
        
        [HttpGet("details-tv/{id}")]
        public async Task<IActionResult> GetTvDetails(int id)
        {
            var result = await _tmdbService.GetTvDetails(id);
            return Ok(result);
        }
        
        [HttpGet("popular-tv")]
        public async Task<IActionResult> GetPopularTv()
        {
            var result = await _tmdbService.GetPopularTv();
            return Ok(result);
        }

        [HttpGet("popular-movies")]
        public async Task<IActionResult> GetPopularMovies()
        {
            var result = await _tmdbService.GetPopularMovies();
            return Ok(result);
        }
    }
}