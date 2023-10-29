using MediatR;
using SprintPlanning.Features.Sprints.Responses;

namespace SprintPlanning.Features.Sprints.Queries;

public sealed record GetSprintTicketsQuery(int SprintId) : IRequest<List<TicketResponse>>
{
}
