namespace SprintPlanning.ExternalServices.Jira;

public sealed record JiraSearchBacklogRequest(
    string Jql,
    int MaxResults = 1000,
    int StartAt = 0)
{
}
