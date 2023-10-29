namespace SprintPlanning.ExternalServices.Jira.Dtos;

public record Ticket(
    string Expand,
    string Id,
    string Self,
    string Key,
    Fields Fields
);
