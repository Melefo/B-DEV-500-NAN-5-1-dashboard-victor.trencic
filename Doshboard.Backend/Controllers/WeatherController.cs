using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doshboard.Backend.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _service;

        public WeatherController(WeatherService service) =>
            _service = service;

        [HttpGet]
        public async Task<ActionResult<WeatherData>> Get(string city)
        {
            WeatherData? response = await _service.Get();

            if (response == null)
                return BadRequest();
            return response;
        }

        [HttpPost]
        public void Configure(string? city, UnitType? unit)
        {
            _service.Configure(city, unit);
        }
    }
}
