using Doshboard.Backend.Entities.Widgets;
using Doshboard.Backend.Exceptions;
using Doshboard.Backend.Models.Widgets;
using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Doshboard.Backend.Controllers
{
    [Authorize]
    [Route("services/[controller]")]
    [ApiController]
    public class SteamController : ControllerBase
    {
        private readonly SteamService _service;

        public SteamController(SteamService service)
            => _service = service;

        [HttpGet(GameWidget.Name)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GameData>> GetGame([BindRequired]string id)
        {
            try
            {
                return await _service.GetGameData(id);
            }
            catch (MongoException ex)
            {
                return BadRequest(new { error = ex.Message });

            }
            catch (ApiException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = ex.Message });

            }
            catch (WidgetException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }


        [HttpPatch(GameWidget.Name)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult> ConfigureGame([FromBody]GameModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);
            try
            {
                await _service.ConfigureGame(model.Id, model.Name);
            }
            catch (MongoException ex)
            {
                return BadRequest(new { error = ex.Message });

            }
            catch (ApiException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = ex.Message });

            }
            catch (WidgetException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            return Accepted();
        }
    }
}
