using SprintPlanning.ExternalServices.Jira.Dtos;

namespace SprintPlanning.ExternalServices.Jira;

public interface IJiraService
{
    public Task<Sprint> GetSprint(CancellationToken cancellationToken);

    public Task<Backlog> GetBacklog(CancellationToken cancellationToken);

}
