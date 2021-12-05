using Doshboard.Backend.Models.Widgets;
using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doshboard.Backend.Controllers
{
    [Route("services/[controller]")]
    [ApiController]
    public class FootController : ControllerBase
    {
        private readonly FootService _service;

        public FootController(FootService service) =>
            _service = service;

        [HttpGet("competition")]
        public async Task<ActionResult<List<CompetitionData>>> GetCompetitions()
        {
            List<CompetitionData>? response = await _service.GetCompetitions();

            if (response == null)
                return BadRequest();
            return response;
        }

        [HttpGet("competition/{id:int}")]
        public async Task<ActionResult<CompetitionData>> GetCompetitionById(string id)
        {
            CompetitionData? response = await _service.GetCompetitionById(id);

            if (response == null)
                return BadRequest();
            return response;
        }

        [HttpGet("match")]
        public async Task<ActionResult<FootJson>> GetTeamsByCompetition(string competitionId)
        {
            FootJson? response = await _service.GetTeams(competitionId);

            if (response == null)
                return BadRequest();
            return response;
        }

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