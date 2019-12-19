using GQL.UserService.Domain.Models;
using GQL.UserService.Filters;
using GQL.UserService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GQL.UserService.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService; 
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        [ValidateModel]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistration userRegistration)
        {
            var result = await _authService.RegisterUserAsync(userRegistration);
            if (result.IsSuccess)
                return Ok( new { result.UserId, result.IsSuccess });
            else
                // TODO : add exception logging
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [HttpPost("LogIn")]
        [ValidateModel]
        public async Task<IActionResult> LogInUser([FromBody] UserAuthentication userAuthentication)
        {
            var result = await _authService.AuthenticateUserAsync(userAuthentication);
            if (result.IsSuccess)
                return Ok( new { result.IsSuccess, result.Token, result.User });
            else
                // TODO : add exception logging
                return BadRequest(result.Message);
        }

        [HttpGet("Key/{key}")]
        public async Task<IActionResult> GetApiKey(string key)
        {
            var result = await _authService.GetApiKeyAsync(key);
            return Ok(new { result.ApiKey, result.IsSuccess });
        }
    }
}
