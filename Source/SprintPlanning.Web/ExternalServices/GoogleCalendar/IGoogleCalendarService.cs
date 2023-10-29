using SprintPlanning.ExternalServices.GoogleCalendar.Enums;
using SprintPlanning.ExternalServices.GoogleCalendar.Models;

namespace SprintPlanning.ExternalServices.GoogleCalendar;

public interface IGoogleCalendarService
{
    Task<CalendarEvent> GetCalendarEvent(
        Countries country,
        CancellationToken cancellationToken);
}
