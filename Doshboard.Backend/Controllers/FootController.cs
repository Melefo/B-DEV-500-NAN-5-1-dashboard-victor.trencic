using Doshboard.Backend.Entities.Widgets;
using Doshboard.Backend.Exceptions;
using Doshboard.Backend.Models.Widgets;
using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doshboard.Backend.Controllers
{
    [Authorize]
    [Route("services/[controller]")]
    [ApiController]
    public class FootController : ControllerBase
    {
        private readonly FootService _service;

        public FootController(FootService service) =>
            _service = service;

        [HttpGet("competitions")]
        public async Task<ActionResult<List<CompetitionData>>> GetCompetitions()
        {
            try
            {
                return await _service.GetCompetitions();
            }
            catch (ApiException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = ex.Message });
            }
        }

        [HttpGet(FootWidget.Name)]
        public async Task<ActionResult<FootJson>> GetTeamsByCompetition(string id)
        {
            try
            {
                return await _service.GetTeams(id);
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

        [HttpPatch(FootWidget.Name)]
        public ActionResult ConfigureTeamsByCompetition([FromBody] FootModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);
            try
            {
                _service.ConfigureFootCompetition(model.Id, model.Competition);
            }
            catch (MongoException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            return Accepted();
        }

        [HttpGet("team/{id:int}")]
        public async Task<ActionResult<FootTeamJson>> TeamsByCompetition(string id)
        {
            try
            {
                return await _service.GetTeam(id);
            }
            catch (ApiException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = ex.Message });
            }
        }
    }
}