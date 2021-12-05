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
    public class RssController : ControllerBase
    {
        private readonly RssService _service;

        public RssController(RssService service)
            => _service = service;

        [HttpGet(FeedWidget.Name)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<FeedData> GetFeed([BindRequired] string id)
        {
            try
            {
                return _service.GetFeed(id);
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

        [HttpPatch(FeedWidget.Name)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult ConfigureFeed([FromBody] FeedModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);
            try
            {
                _service.ConfigureFeed(model.Id, model.Url, model.Items);
            }
            catch (MongoException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            return Accepted();
        }
    }
}