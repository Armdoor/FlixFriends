using FlixFriends.Dtos;
using FlixFriends.Interfaces;
using FlixFriends.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlixFriends.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
   private readonly UserManager<User> _userManager;
   private readonly ITokenService _tokenService;
   private readonly SignInManager<User> _signinManager;
   public UserController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signinManager)
   {
      _userManager = userManager;
      _tokenService = tokenService;
      _signinManager = signinManager;
   }
   
   [HttpPost("login")]
   public async Task<IActionResult> Login(LoginDto loginDto)
   {
      if (!ModelState.IsValid)
         return BadRequest(ModelState);

      // Ensure at least one of the username or email is provided
      if (string.IsNullOrWhiteSpace(loginDto.Email) && string.IsNullOrWhiteSpace(loginDto.Username))
         return BadRequest("Either email or username must be provided.");

      // Find user by email or username
      var user = await _userManager.Users
         .FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower() || x.Email.ToLower() == loginDto.Email.ToLower());

      if (user == null)
         return Unauthorized("Invalid username or email!");

      // Check the password
      var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

      if (!result.Succeeded)
         return Unauthorized("Password incorrect");

      // Generate the token and return user information
      return Ok(
         new NewUserDto
         {
            UserName = user.UserName,
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
         }
      );
   }
   
   [HttpPost("register")]
   public async Task<IActionResult> Register([FromBody] RegisterUser registerDto)
   {
      try
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

         var user = new User
         {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            UserName = registerDto.Username,
            Email = registerDto.Email
         };

         var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

         if (createdUser.Succeeded)
         {
            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (roleResult.Succeeded)
            {
               return Ok(
                  new NewUserDto
                  {
                     FirstName = user.FirstName,
                     LastName = user.LastName,
                     UserName = user.UserName,
                     Email = user.Email,
                     Token = _tokenService.CreateToken(user)
                  }
               );
            }
            else
            {
               return StatusCode(500, roleResult.Errors);
            }
         }
         else
         {
            return StatusCode(500, createdUser.Errors);
         }
      }
      catch (Exception e)
      {
         return StatusCode(500, e);
      }
   }
}