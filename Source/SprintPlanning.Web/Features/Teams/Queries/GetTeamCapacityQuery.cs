using MediatR;
using SprintPlanning.Features.Teams.Responses;

namespace SprintPlanning.Features.Teams.Queries;

public sealed record GetTeamCapacityQuery(DateTime StartDate) : IRequest<List<TeamMemberCapacityResponse>>
{

}