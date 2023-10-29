namespace SprintPlanning.ExternalServices.GoogleCalendar.Models;

public record CalendarItem(
    string Id,
    string Status,
    string Summary,
    string Description,
    EventDate Start,
    EventDate End);
