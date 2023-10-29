using SprintPlanning.ExternalServices.GoogleCalendar.Enums;

namespace SprintPlanning.Features.Teams.Responses;

public record PublicHolidayResponse(
    Countries Country,
    string CountryName,
    string Summary,
    string Description,
    DateTime Start,
    DateTime End);
