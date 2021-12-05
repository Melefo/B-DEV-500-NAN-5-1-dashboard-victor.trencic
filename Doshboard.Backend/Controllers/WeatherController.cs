using Doshboard.Backend.Entities;
using Doshboard.Backend.Entities.Widgets;
using Doshboard.Backend.Exceptions;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CityTempData>> GetCityTemperature([BindRequired]string id)
        {
            try
            {
                return await _service.GetCityTemp(id);
            }
            catch (MongoException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (ApiException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = ex.Message });

            }
        }

        [HttpPatch(CityTempWidget.Name)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult ConfigureCityTemperature([FromBody] CityTempModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);
            try
            {
                _service.ConfigureCityTemp(model.Id, model.City, model.Unit);
            }
            catch (MongoException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            return Accepted();
        }
    }
}
