using TeamPlanning.Application.Contracts.Models;

namespace TeamPlanning.Application.Contracts.Interfaces
{
    public interface IPublicHolidayService
    {
        Task<PublicHoliday> GetByCountryName(string countryName);
    }
}
