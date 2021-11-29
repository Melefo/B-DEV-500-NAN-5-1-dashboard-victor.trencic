using Doshboard.Backend.Entities;
using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doshboard.Backend.Controllers
{
    [Authorize]
    [Route("services/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _service;

        public WeatherController(WeatherService service) =>
            _service = service;

        [HttpGet]
        public async Task<ActionResult<WeatherData>> Get()
        {
            WeatherData? response = await _service.Get(User.Identity!.Name!);

            if (response == null)
                return BadRequest();
            return response;
        }

        [HttpPost]
        public void Configure(string? city, UnitType? unit) => 
            _service.Configure(User.Identity!.Name!, city, unit);
    }
}
