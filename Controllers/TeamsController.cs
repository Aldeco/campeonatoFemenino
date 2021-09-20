using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using Project1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamService;

        public TeamsController(ITeamsService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IEnumerable<Team>> Get()
        {
            return await _teamService.GetTeamsList();
        }
        // GET: api/Teams/5
        [HttpGet("{team_id}")]
        public async Task<ActionResult<Team>> Get(int team_id)
        {
            var team = await _teamService.GetTeamByID(team_id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        // POST: api/Teams
        [HttpPost]
        public async Task<ActionResult<Team>> Post(Team team)
        {
            await _teamService.CreateTeam(team);

            return CreatedAtAction("Post", new { team_id = team.TeamId }, team);
        }

        // PUT: api/Teams/5
        [HttpPut("{team_id}")]
        public async Task<IActionResult> Put(int team_id, Team team)
        {
            if (team_id != team.TeamId)
            {
                return BadRequest("Not a valid team id");
            }

            await _teamService.UpdateTeam(team);

            return NoContent();
        }

        // DELETE: api/Teams/5
        [HttpDelete("{team_id}")]
        public async Task<IActionResult> Delete(int team_id)
        {
            if (team_id <= 0)
                return BadRequest("Not a valid team id");

            var team = await _teamService.GetTeamByID(team_id);
            if (team == null)
            {
                return NotFound();
            }

            await _teamService.DeleteTeam(team);

            return NoContent();
        }
    }
}
