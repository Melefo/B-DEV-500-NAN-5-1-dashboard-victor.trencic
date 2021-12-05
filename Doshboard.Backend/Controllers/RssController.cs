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
    public class RssController : ControllerBase
    {
        private readonly RssService _service;

        public RssController(RssService service)
            => _service = service;

        [HttpGet(FeedWidget.Name)]
        public async Task<ActionResult<FeedData>> GetFeed([BindRequired] string id)
        {
            FeedData? response = await _service.GetFeed(id);

            if (response == null)
                return BadRequest();
            return response;
        }

        [HttpPatch(FeedWidget.Name)]
        public ActionResult ConfigureFeed([FromBody] FeedModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _service.ConfigureFeed(model.Id, model.Url, model.Items);
            return NoContent();
        }
    }
}
