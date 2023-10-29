using MediatR;
using SprintPlanning.ExternalServices.Jira;
using SprintPlanning.Features.Sprints.Responses;

namespace SprintPlanning.Features.Sprints.Queries;

public sealed class GetSprintDetailsQueryHandler : IRequestHandler<GetSprintDetailsQuery, SprintResponse>
{
    private readonly IJiraService _jiraService;

    public GetSprintDetailsQueryHandler(IJiraService jiraService)
    {
        _jiraService = jiraService ?? throw new ArgumentNullException(nameof(jiraService));
    }

    public async Task<SprintResponse> Handle(GetSprintDetailsQuery request, CancellationToken cancellationToken)
    {
        var sprint = await _jiraService.GetSprint(cancellationToken);

        var sprintItem = sprint.Values
            .Where(si => si.Id == request.SprintId)
            .Select(sprintItem =>
            new SprintResponse(
                sprintItem.Id,
                sprintItem.Name,
                sprintItem.StartDate,
                sprintItem.EndDate))
            .FirstOrDefault();

        return sprintItem ?? throw new ArgumentException("Invalid Sprint Id");
    }
}







