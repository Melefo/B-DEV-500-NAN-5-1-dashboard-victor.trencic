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
    public class CryptoController : ControllerBase
    {
        private readonly CryptoService _service;

        public CryptoController(CryptoService service)
            => _service = service;

        [HttpGet(RealTimeCryptoWidget.Name)]
        public async Task<ActionResult<RealTimeCryptoData>> GetRealTimeCrypto([BindRequired]string id)
        {
            RealTimeCryptoData? response = await _service.GetRealTimeCrypto(id);

            if (response == null)
                return BadRequest();
            return response;
        }

        [HttpPatch(RealTimeCryptoWidget.Name)]
        public ActionResult ConfigureRealTimeCrypto([FromBody] RealTimeCryptoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _service.ConfigureRealTimeCrypto(model.Id, model.Currency, model.Convert);
            return NoContent();
        }
    }
}
