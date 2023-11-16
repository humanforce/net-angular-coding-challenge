using Microsoft.AspNetCore.Mvc;
using TeamPlanning.Application.Contracts.Interfaces;

namespace TeamPlanning.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamMemberController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() {
            var result = await _teamMemberService.GetAll();
            if (result != null) return Ok(result);
            return NotFound();
        }
    }
}
