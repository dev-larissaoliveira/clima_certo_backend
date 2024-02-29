using ClimaTempoWebAPI.Contracts.Login;
using ClimaTempoWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimaTempoWebAPI.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(ILoginService loginService) : ControllerBase
{
    private readonly ILoginService _loginService = loginService;

    [HttpPost("login")]
    public Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var obj = _loginService.SignIn(request);
        return Task.FromResult<IActionResult>(Ok(new LoginResponse { Token = obj.Token }));
    }
}