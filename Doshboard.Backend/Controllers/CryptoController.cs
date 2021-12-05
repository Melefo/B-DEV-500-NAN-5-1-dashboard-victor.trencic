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
    public class CryptoController : ControllerBase
    {
        private readonly CryptoService _service;

        public CryptoController(CryptoService service)
            => _service = service;

        [HttpGet(RealTimeCryptoWidget.Name)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RealTimeCryptoData>> GetRealTimeCrypto([BindRequired] string id)
        {
            try
            {
                return await _service.GetRealTimeCrypto(id);
            }
            catch (ApiException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = ex.Message });
            }
            catch (MongoException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPatch(RealTimeCryptoWidget.Name)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult ConfigureRealTimeCrypto([FromBody] RealTimeCryptoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);
            try
            {
                _service.ConfigureRealTimeCrypto(model.Id, model.Currency, model.Convert);
            }
            catch (MongoException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            return Accepted();
        }
    }
}