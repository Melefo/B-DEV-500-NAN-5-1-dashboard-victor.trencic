using Doshboard.Backend.Entities;
using Doshboard.Backend.Entities.Widgets;
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

        [HttpGet(CityTempWidget.Name)]
        public async Task<ActionResult<CityTempData>> GetCityTemperature([BindRequired]string id)
        {
            CityTempData? response = await _service.GetCityTemp(id);

            if (response == null)
                return BadRequest();
            return response;
        }

        [HttpPatch(CityTempWidget.Name)]
        public ActionResult ConfigureCityTemperature([FromBody] CityTempModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _service.ConfigureCityTemp(model.Id, model.City, model.Unit);
            return NoContent();
        }
    }
}
