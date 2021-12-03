using Doshboard.Backend.Entities.Widgets;
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
        public async Task<ActionResult<GameData>> GetGame([BindRequired]string id)
        {
            GameData? response = await _service.GetGameData(id);

            if (response == null)
                return BadRequest();
            return response;
        }


        [HttpPatch(GameWidget.Name)]
        public ActionResult ConfigureGame([BindRequired]string id, [BindRequired]string name)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _service.ConfigureGame(id, name);
            return NoContent();
        }
    }
}
