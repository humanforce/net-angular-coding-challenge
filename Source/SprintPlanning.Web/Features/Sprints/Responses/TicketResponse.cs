namespace SprintPlanning.Features.Sprints.Responses;

public sealed record TicketResponse(
    string Id,
    string SprintName,
    string Summary,
    double Velocity);

