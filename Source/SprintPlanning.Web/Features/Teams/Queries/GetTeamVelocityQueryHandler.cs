using MediatR;
using SprintPlanning.ExternalServices.Jira;
using SprintPlanning.Features.Teams.Responses;

namespace SprintPlanning.Features.Teams.Queries;

public sealed class GetTeamVelocityQueryHandler : IRequestHandler<GetTeamVelocityQuery, TeamVelocityResponse>
{
    private readonly IJiraService _jiraService;

    private const int SprintDays = 14; //Two weeks sprint
    public GetTeamVelocityQueryHandler(IJiraService jiraService)
    {
        _jiraService = jiraService;
    }

    public async Task<TeamVelocityResponse> Handle(GetTeamVelocityQuery request, CancellationToken cancellationToken)
    {
        var startDate = request.SprintStartDate.AddDays(-(SprintDays * 3));

        var backlog = await _jiraService.GetBacklog(cancellationToken);

        var velocity = backlog.Issues
              .Where(issue => issue.Fields.Customfield_10020
              .Any(item => item.StartDate >= startDate
                && item.StartDate <= request.SprintStartDate
                && item.EndDate >= startDate
                && item.EndDate <= request.SprintStartDate))
              .Sum(issue => issue.Fields.Customfield_10016);

        return new TeamVelocityResponse(velocity);
    }
}
