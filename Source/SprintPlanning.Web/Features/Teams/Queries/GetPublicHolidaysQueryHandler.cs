using MediatR;
using SprintPlanning.Common.Extensions;
using SprintPlanning.ExternalServices.GoogleCalendar;
using SprintPlanning.ExternalServices.GoogleCalendar.Enums;
using SprintPlanning.ExternalServices.GoogleCalendar.Models;
using SprintPlanning.Features.Teams.Responses;

namespace SprintPlanning.Features.Teams.Queries;

public class GetPublicHolidaysQueryHandler : IRequestHandler<GetPublicHolidaysQuery, List<PublicHolidayResponse>>
{
    private readonly IGoogleCalendarService _googleCalendarService;

    public GetPublicHolidaysQueryHandler(IGoogleCalendarService googleCalendarService)
    {
        _googleCalendarService = googleCalendarService;
    }

    public async Task<List<PublicHolidayResponse>> Handle(
        GetPublicHolidaysQuery request,
        CancellationToken cancellationToken)
    {
        List<PublicHolidayResponse> publicHolidays = new();

        foreach (Countries country in Enum.GetValues(typeof(Countries)))
        {
            var calendarEvent = await _googleCalendarService.GetCalendarEvent(
                 country,
                 cancellationToken);

            publicHolidays.AddRange(
             GetPublicHolidays(
                 calendarEvent,
                 country,
                 request.StartDate,
                 request.EndDate));
        }



        return publicHolidays;
    }

    private static List<PublicHolidayResponse> GetPublicHolidays(
      CalendarEvent calendarEvent,
      Countries country,
      DateTime startDate,
      DateTime endDate)
    {
        return calendarEvent.Items
            .Where(item => item.Start.Date >= startDate
              && item.Start.Date <= endDate
              && item.End.Date >= startDate
              && item.End.Date <= endDate)
            .Select(publicHodliday => new PublicHolidayResponse(
                country,
                country.Description(),
                publicHodliday.Summary,
                publicHodliday.Description,
                publicHodliday.Start.Date,
                publicHodliday.End.Date))
            .ToList();
    }
}
