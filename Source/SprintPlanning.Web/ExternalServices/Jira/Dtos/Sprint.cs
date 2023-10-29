namespace SprintPlanning.ExternalServices.Jira.Dtos;

public record Sprint(
    int MaxResults,
    int StartAt,
    bool IsLast,
    List<SprintItem> Values
);

