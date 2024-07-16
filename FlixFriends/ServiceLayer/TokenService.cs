using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FlixFriends.Interfaces;
using FlixFriends.Models;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace FlixFriends.ServiceLayer;

public class TokenService: ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config)
    {
        _config = config;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
    }

    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
            new Claim("FirstName", user.FirstName ?? string.Empty),
            new Claim("LastName", user.LastName ?? string.Empty)
        };
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        DateTime now = DateTime.UtcNow;
        DateTime expires = now.AddMinutes(Convert.ToDouble(_config["JWT:DurationInMinutes"]));
        DateTime notBefore = now;
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expires,
            NotBefore = notBefore,
            SigningCredentials = creds,
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"]
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}