using MediatR;
using SprintPlanning.ExternalServices.Jira;
using SprintPlanning.Features.Sprints.Responses;

namespace SprintPlanning.Features.Sprints.Queries;

public sealed class GetSprintsQueryHandler : IRequestHandler<GetSprintsQuery, List<SprintResponse>>
{
    private readonly IJiraService _jiraService;

    public GetSprintsQueryHandler(IJiraService jiraService)
    {
        _jiraService = jiraService ?? throw new ArgumentNullException(nameof(jiraService));
    }

    public async Task<List<SprintResponse>> Handle(GetSprintsQuery request, CancellationToken cancellationToken)
    {
        var sprint = await _jiraService.GetSprint(cancellationToken);

        var sprintItems = sprint.Values.Select(sprintItem =>
            new SprintResponse(
                sprintItem.Id,
                sprintItem.Name,
                sprintItem.StartDate,
                sprintItem.EndDate))
            .ToList();

        return sprintItems;
    }
}







