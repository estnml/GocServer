using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GocServer.Application.DTOs.Auth;
using GocServer.Application.Services;

namespace GocServer.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequestDto loginRequest)
        {
            return await _authService.Login(loginRequest);
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequestDto registerRequest)
        {
            return await _authService.Register(registerRequest);
        }
    }
}
