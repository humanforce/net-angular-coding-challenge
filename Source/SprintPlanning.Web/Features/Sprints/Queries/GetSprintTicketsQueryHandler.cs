using MediatR;
using SprintPlanning.ExternalServices.Jira;
using SprintPlanning.Features.Sprints.Responses;

namespace SprintPlanning.Features.Sprints.Queries;

public class GetSprintTicketsQueryHandler : IRequestHandler<GetSprintTicketsQuery, List<TicketResponse>>
{
    private readonly IJiraService _jiraService;

    public GetSprintTicketsQueryHandler(IJiraService jiraService)
    {
        _jiraService = jiraService;
    }

    public async Task<List<TicketResponse>> Handle(GetSprintTicketsQuery request, CancellationToken cancellationToken)
    {
        var backlog = await _jiraService.GetBacklog(cancellationToken);


        var tickets = backlog.Issues
            .Where(issue => issue.Fields.Customfield_10020
            .Any(s => s.Id == request.SprintId))
            .Select(ticket => new TicketResponse(ticket.Id,
                ticket.Fields.Customfield_10020[0].Name,
                ticket.Fields.Summary,
                ticket.Fields.Customfield_10016))
            .ToList();

        return tickets;
    }
}
