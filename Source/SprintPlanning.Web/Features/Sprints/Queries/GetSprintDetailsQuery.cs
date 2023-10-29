using MediatR;
using SprintPlanning.Features.Sprints.Responses;

namespace SprintPlanning.Features.Sprints.Queries;

public sealed record GetSprintDetailsQuery(int SprintId) : IRequest<SprintResponse>
{

}
