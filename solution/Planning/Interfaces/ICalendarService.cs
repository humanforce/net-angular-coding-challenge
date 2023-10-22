using Planning.Models;

namespace Planning;

public interface ICalendarService
{
    Task<string?> GetPublicHolidays(Region region);
}
