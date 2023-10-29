using MediatR;
using SprintPlanning.Features.Teams.Responses;

namespace SprintPlanning.Features.Teams.Queries;

public sealed record GetPublicHolidaysQuery(
    DateTime StartDate,
    DateTime EndDate) : IRequest<List<PublicHolidayResponse>>
{
}
