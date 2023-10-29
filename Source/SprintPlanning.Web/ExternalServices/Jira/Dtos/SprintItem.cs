namespace SprintPlanning.ExternalServices.Jira.Dtos;

public record SprintItem(
    int Id,
    string Name,
    DateTime StartDate,
    DateTime EndDate
);

