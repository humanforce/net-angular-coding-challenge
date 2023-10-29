using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SprintPlanning.Features.Teams.Queries;
using SprintPlanning.Features.Teams.Requests;
using SprintPlanning.Features.Teams.Responses;

namespace SprintPlanning.EndPoints;

public static class TeamMemberEndPoints
{
    public static void MapTeamMemberEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/team-members");

        group.MapPost("/holidays", GetPublicHoliday);

        group.MapPost("/velocity", GetTeamVelocity);

        group.MapPost("/capacity", GetTeamCapacity);
    }

    public static async Task<Ok<List<PublicHolidayResponse>>> GetPublicHoliday(ISender sender,
          GetPublicHolidaysRequest request,
          CancellationToken cancellationToken)
    {
        var result = await sender.Send(
               new GetPublicHolidaysQuery(
               request.StartDate,
               request.EndDate),
               cancellationToken);

        return TypedResults.Ok(result);
    }

    public static async Task<Ok<List<TeamMemberCapacityResponse>>> GetTeamVelocity(ISender sender,
        GetTeamCapacityRequest request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetTeamCapacityQuery(
            request.StartDate),
            cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async Task<Ok<List<TeamMemberCapacityResponse>>> GetTeamCapacity(ISender sender,
          GetTeamCapacityRequest request,
          CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetTeamCapacityQuery(
            request.StartDate),
            cancellationToken);

        return TypedResults.Ok(response);
    }
}
