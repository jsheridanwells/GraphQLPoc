using System.Security.Claims;
using System.Threading.Tasks;
using GQL.AppService.Domain.Models;
using GQL.AppService.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GQL.AppService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeightController : ControllerBase
    {
        private readonly IWeightService _weightService;

        public WeightController(IWeightService weightService)
        {
            _weightService = weightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeightByUserId()
        {
            // TODO : finish this
            var tempUserId = "6B75F005-05B1-4DBA-DFA5-08D77831AAAC";
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            var weights = await _weightService.GetWeightsByUserId(userId);
            return Ok(weights);
        }

        [HttpPost("Log")]
        public async Task<IActionResult> LogWeight([FromBody] LogWeightDto logDto)
        {
            // TODO : finish this
            var result = await _weightService.LogWeight(logDto);
            return Ok(new { result.IsSuccess });
        }

    }
}
