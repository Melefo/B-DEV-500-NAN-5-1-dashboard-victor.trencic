using Doshboard.Backend.Models.Widgets;
using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doshboard.Backend.Controllers
{
    /// <summary>
    /// Foot Controller route
    /// </summary>
    [Authorize]
    [Route("services/[controller]")]
    [ApiController]
    public class FootController : ControllerBase
    {
        private readonly FootService _service;

        public FootController(FootService service) =>
            _service = service;

        /// <summary>
        /// get all competition
        /// </summary>
        /// <returns></returns>
        [HttpGet("competition")]
        public async Task<ActionResult<List<CompetitionData>>> GetCompetitions()
        {
            List<CompetitionData>? response = await _service.GetCompetitions();

            if (response == null)
                return BadRequest();
            return response;
        }

        /// <summary>
        /// get competition by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("competition/{id:int}")]
        public async Task<ActionResult<CompetitionData>> GetCompetitionById(string id)
        {
            CompetitionData? response = await _service.GetCompetitionById(id);

            if (response == null)
                return BadRequest();
            return response;
        }

        /// <summary>
        /// get match by competitionId
        /// </summary>
        /// <param name="competitionId"></param>
        /// <returns></returns>
        [HttpGet("match")]
        public async Task<ActionResult<FootJson>> GetTeamsByCompetition(string competitionId)
        {
            FootJson? response = await _service.GetTeams(competitionId);

            if (response == null)
                return BadRequest();
            return response;
        }

        /// <summary>
        /// Get team by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("team/{id:int}")]
        public async Task<ActionResult<FootTeamJson>> GetTeamById(string id)
        {
            FootTeamJson? response = await _service.GetTeam(id);

            if (response == null)
                return BadRequest();
            return response;
        }
    }
}