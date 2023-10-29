using MediatR;
using SprintPlanning.Features.Teams.Responses;

namespace SprintPlanning.Features.Teams.Queries;

public sealed record GetTeamVelocityQuery(DateTime SprintStartDate) : IRequest<TeamVelocityResponse>
{
}
