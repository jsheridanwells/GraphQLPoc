using System.Threading.Tasks;
using GQL.AppService.Domain.Models;
using GQL.AppService.Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GQL.AppService.Controllers
{
    [Route("[controller]")]
    public class CalorieController : Controller
    {
        private readonly ICalorieService _service;

        public CalorieController(ICalorieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCaloriesByUserId()
        {
            // TODO : Finish this
            var tempUserId = "6B75F005-05B1-4DBA-DFA5-08D77831AAAC";
            var calories = await _service.GetCaloriesByUserId(tempUserId);
            return Ok(calories);
        }

        [HttpPost("Log")]
        public async Task<IActionResult> LogCalorie([FromBody] LogCalorieDto logDto)
        {
            // TODO : finish this
            var result = await _service.LogCalorie(logDto);
            return Ok(new { result.IsSuccess });
        }
    }
}
