using Microsoft.AspNetCore.Mvc;
using User.Application;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
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
}