using System;
using System.Threading.Tasks;
using GQL.UserService.Filters;
using GQL.UserService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GQL.UserService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IAuthService _authService;
        public UsersController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("{id}")]
        [ValidateModel]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var user = await _authService.GetUserAsync(id);
                if (user.IsSuccess)
                    return Ok(user);
                else
                    return NotFound($"No user with an ID of { id } was found.");
            }
            catch (Exception e)
            {
                // TODO : add exception logging 
                return BadRequest();
            }
        }
    }
}
