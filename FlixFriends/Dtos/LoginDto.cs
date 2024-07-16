using Microsoft.Build.Framework;

namespace FlixFriends.Dtos;

public class LoginDto
{
    [EmailOrUsernameRequired]
    public string Email { get; set; }
    [EmailOrUsernameRequired]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}