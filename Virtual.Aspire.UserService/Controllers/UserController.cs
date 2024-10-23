using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Virtual.Aspire.UserService.Entities;

namespace Virtual.Aspire.UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserContext _context;

    public UserController(UserContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Register), new { id = user.UserId }, user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(UserLoginDto loginDto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
        {
            return Unauthorized();
        }

        return user;
    }
}

public class UserLoginDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
