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
      // Ensure username is provided
      if (string.IsNullOrWhiteSpace(loginDto.Username))
         return BadRequest("Username must be provided.");

      var user = await _userManager.Users
         .FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

      if (user == null)
         return Unauthorized("Invalid username!");

      var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

      if (!result.Succeeded)
         return Unauthorized("Password incorrect");


      return Ok(new NewUserDto
      {
         FirstName = user.FirstName,
         LastName = user.LastName,
         Email = user.Email,
         UserName = user.UserName,
         Token = _tokenService.CreateToken(user)
      });
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
   
   [HttpPost("logout")]
   public async Task<IActionResult> Logout()
   {
      await _signinManager.SignOutAsync();
      return Ok("Logged out");
   }
   
   [HttpPost("upload-profile-picture")]
   public async Task<IActionResult> UploadProfilePicture(IFormFile file)
   {
      if (file == null || file.Length == 0)
         return BadRequest("No file uploaded.");

      var user = await _userManager.GetUserAsync(User);
      if (user == null)
         return Unauthorized();

      using (var memoryStream = new MemoryStream())
      {
         await file.CopyToAsync(memoryStream);
         user.Image = memoryStream.ToArray();
      }

      var result = await _userManager.UpdateAsync(user);
      if (!result.Succeeded)
         return StatusCode(500, "Error updating user profile picture.");

      return Ok("Profile picture uploaded successfully.");
   }
}