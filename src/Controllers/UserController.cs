using ClimaTempoWebAPI.Contracts.User;
using ClimaTempoWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimaTempoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken = default) =>
                Ok(await _userService.GetUsersAsync(cancellationToken));

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser(UserRequest request)
        {
            _userService.AddUser(request);
            return NoContent();
        }
    }
}
