using Microsoft.AspNetCore.Mvc;
using User.Application;
using User.Domain;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User.Domain.User user)
    {
        await _userService.Register(user);
        return Ok(user.Id);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(User.Domain.User user)
    {
        var dbUser = await _userService.Login(user.Email, user.Password);
        if (dbUser != null)
        {
            // TODO: Create and return a JWT for authorization
            return Ok(dbUser.Id);
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpGet("ping")]
    public async Task<IActionResult> Ping()
    {
        return await Task.FromResult(Ok("Ping"));
    }

}