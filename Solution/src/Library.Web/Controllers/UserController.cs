using System.Security.Authentication;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [Authorize(Roles = "Admin,Librarian")]
    [HttpPost]
    public async Task<User> CreateUserAsync(User newUser)
    {
        await _userService.CreateUserAsync(newUser);

        return newUser;
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUserAsync(Guid userId)
    {
        await _userService.DeleteUserAsync(userId);

        return NoContent();
    }

    [Authorize(Roles = "Admin,Librarian")]
    [HttpGet("{userId}")]
    public async Task<User> GetUserByIdAsync(Guid userId)
    {
        User user = await _userService.GetUserByIdAsync(userId);

        return user;
    }

    [Authorize(Roles = "Admin,Librarian")]
    [HttpGet]
    public async Task<List<User>> GetUsersAsync()
    {
        return await _userService.GetUsersAsync();
    }

    [Authorize(Roles = "Admin,Librarian")]
    [HttpPut("{userId}")]
    public async Task<User> UpdateUserAsync(Guid userId, User updatedUser)
    {
        var user = await _userService.UpdateUserAsync(userId, updatedUser);

        return user;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO loginDto)
    {
        try
        {
            var token = await _userService.LoginAsync(loginDto);
            return Ok(new { Token = token });
        }
        catch (AuthenticationException ex)
        {
            return Unauthorized(new { Message = ex.Message });
        }
    }
}