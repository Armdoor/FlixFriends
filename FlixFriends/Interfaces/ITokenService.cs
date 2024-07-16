using FlixFriends.Models;
namespace FlixFriends.Interfaces;

public interface ITokenService
{
     string CreateToken(User user);
}