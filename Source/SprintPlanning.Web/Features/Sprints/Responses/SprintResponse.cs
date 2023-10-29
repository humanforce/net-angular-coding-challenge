namespace SprintPlanning.Features.Sprints.Responses;

public record SprintResponse(
    int Id,
    string Name,
    DateTime StartDate,
    DateTime EndDate
);

