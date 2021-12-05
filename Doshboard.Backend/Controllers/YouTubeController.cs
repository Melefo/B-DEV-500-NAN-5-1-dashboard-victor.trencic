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
    /// <summary>
    /// Youtube controller route
    /// </summary>
    [Authorize]
    [Route("services/[controller]")]
    [ApiController]
    public class YouTubeController : ControllerBase
    {
        private readonly YouTubeService _service;

        public YouTubeController(YouTubeService service) =>
            _service = service;

        /// <summary>
        /// Get video from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(VideoWidget.Name)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VideoData>> GetVideo([BindRequired] string id)
        {
            try
            {
                return await _service.GetVideoData(id, User.Identity!.Name!);
            }
            catch (ApiException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = ex.Message });
            }
            catch (UserException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
            catch (MongoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Configure Widget
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch(VideoWidget.Name)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult ConfigureVideo([FromBody]VideoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);
            try
            {
                _service.ConfigureVideo(model.Id, model.VideoId);
            }
            catch (MongoException ex)
            {
                return BadRequest(ex.Message);
            }
            return Accepted();
        }

        /// <summary>
        /// Get all video related to an user
        /// </summary>
        /// <returns></returns>
        [HttpGet("uservideos")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Dictionary<string, string>>> GetUserVideos()
        {
            try
            {
                return await _service.GetUserVideos(User.Identity!.Name!);
            }
            catch (UserException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}
