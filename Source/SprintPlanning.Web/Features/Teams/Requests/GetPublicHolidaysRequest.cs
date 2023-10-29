namespace SprintPlanning.Features.Teams.Requests;

public sealed record GetPublicHolidaysRequest(
    DateTime StartDate,
    DateTime EndDate);

