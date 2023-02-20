using EverestEdu.Infrastructure.Abstractions;
using EverstEdu.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EverstEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogiAsync(LoginRequest request)
        {
            var token = await _authService.LoginAsync(request.UserName, request.Password);

            return Ok(token);

        }
    }
}
