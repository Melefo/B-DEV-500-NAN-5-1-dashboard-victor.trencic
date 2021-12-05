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
    public class YouTubeController : ControllerBase
    {
        private readonly YouTubeService _service;

        public YouTubeController(YouTubeService service) =>
            _service = service;

        [HttpGet(VideoWidget.Name)]
        public async Task<ActionResult<VideoData>> GetCityTemperature([BindRequired]string id)
        {
            VideoData? response = await _service.GetVideoData(id, User.Identity!.Name!);

            if (response == null)
                return BadRequest();
            return response;
        }

        [HttpPatch(VideoWidget.Name)]
        public ActionResult ConfigureCityTemperature([BindRequired]string id, [BindRequired]string videoId)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _service.ConfigureVideo(id, videoId);
            return NoContent();
        }

        [HttpGet("uservideos")]
        public async Task<ActionResult<Dictionary<string, string>>> GetUserVideos()
        {
            var res = await _service.GetUserVideos(User.Identity!.Name!);

            if (res == null)
                return BadRequest();
            return res;
        }
    }
}
