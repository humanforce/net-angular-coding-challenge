using Microsoft.AspNetCore.Mvc;
using Planning.Models;

namespace Planning;

[ApiController]
[Route("[controller]")]
public class SprintController : ControllerBase
{
    private readonly ICalendarService _calendarService;
    private readonly IJiraService _jiraService;

    public SprintController(
        ICalendarService calendarService,
        IJiraService jiraService
    ) {
        _calendarService = calendarService;
        _jiraService = jiraService;
    }

    [HttpGet]
    [Route("holidays")]
    public async Task<ActionResult> GetPublicHolidays(Region region)
    {
        var result = await _calendarService.GetPublicHolidays(region);
        if (string.IsNullOrWhiteSpace(result))
            return NoContent();
        return Content(result, "application/json");
    }

    [HttpGet]
    [Route("sprints")]
    public async Task<ActionResult> GetSprints()
    {
        var result = await _jiraService.GetSprints();
        if (string.IsNullOrWhiteSpace(result))
            return NoContent();
        return Content(result, "application/json");
    }

    [HttpGet]
    [Route("backlog")]
    public async Task<ActionResult> GetBacklog()
    {
        var result = await _jiraService.GetBacklog();
        if (string.IsNullOrWhiteSpace(result))
            return NoContent();
        return Content(result, "application/json");
    }
}
