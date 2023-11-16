using Microsoft.AspNetCore.Mvc;
using TeamPlanning.Application.Contracts.Interfaces;

namespace TeamPlanning.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PublicHolidayController : ControllerBase
    {
        private readonly IPublicHolidayService _publicHolidayService;

        public PublicHolidayController(IPublicHolidayService publicHolidayService)
        {
            _publicHolidayService = publicHolidayService;
        }

        [HttpGet("{countryName}")]
        public async Task<ActionResult> GetByCountryName(string countryName) {
            var result = await _publicHolidayService.GetByCountryName(countryName);
            if (result != null) return Ok(result);
            return NotFound();
        }
    }
}
