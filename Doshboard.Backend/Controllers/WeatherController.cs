using Doshboard.Backend.Entities;
using Doshboard.Backend.Models;
using Doshboard.Backend.Models.Widgets;
using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet("city_temperature")]
        public async Task<ActionResult<WeatherData>> GetCityTemperature([BindRequired]string id)
        {
            WeatherData? response = await _service.GetCityTemp(id);

            if (response == null)
                return BadRequest();
            return response;
        }

        [HttpPatch("city_temperature")]
        public ActionResult ConfigureCityTemperature([FromBody] CityTempModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _service.ConfigureCityTemp(model.Id, model.City, model.Unit);
            return NoContent();
        }
    }
}
