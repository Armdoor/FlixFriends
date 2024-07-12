using FlixFriends.Interfaces;
using FlixFriends.Models;
using FlixFriends.ServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace FlixFriends.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediaController : ControllerBase
{
    private readonly ILogger<MediaController> _logger;
    private readonly IMediaService _mediaService;
    
    public MediaController(ILogger<MediaController> logger, IMediaService mediaService )
    {
        _logger = logger;
        _mediaService = mediaService;
    }
    
    [HttpGet("{title}")]
    public async Task<IActionResult> GetMedia([FromRoute] string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return BadRequest("Movie/Series title cannot be empty.");
        }

        try
        {
            var media = await _mediaService.GetMediaAsync(title);
            if (media == null)
            {
                return NotFound($"Movie/Series with title '{title}' not found.");
            }

            return Ok(media);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching the movie/series   .");
            return StatusCode(500, "An error occurred while fetching the movie/series.");
        }
    }
    
}