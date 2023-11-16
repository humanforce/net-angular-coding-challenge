using Microsoft.AspNetCore.Mvc;
using TeamPlanning.Application.Contracts.Interfaces;

namespace TeamPlanning.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SprintController : ControllerBase
    {
        private readonly ISprintService _sprintService;
        public SprintController(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _sprintService.GetAll();
            if (result != null) return Ok(result);
            return NotFound();
        }
    }
}