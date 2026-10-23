


using Application.DTOs.Auth;
using Application.Ports.Inbound;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : Controller
{

    private readonly AuthUseCase _usecase;

    public AuthController(AuthUseCase usecase)
    {
        _usecase = usecase;
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var user = await _usecase.GetCurrentUserFromClaims(User);

        return user == null ? Unauthorized() : Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest dto)
    {
        var result = await _usecase.Login(dto);
        return Ok(result);
    }

}
