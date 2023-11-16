using Microsoft.AspNetCore.Mvc;
using TeamPlanning.Application.Contracts.Interfaces;

namespace TeamPlanning.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BacklogController : ControllerBase
    {
        private readonly IBacklogService _backlogService;

        public BacklogController(IBacklogService backlogService)
        {
            _backlogService = backlogService;
        }

        [HttpGet("{sprintId}")]
        public async Task<ActionResult> GetBySprintId(int sprintId)
        {
            var result = await _backlogService.GetBySprintId(sprintId);
            if (result != null) return Ok(result);
            return NotFound();
        }
    }
}
