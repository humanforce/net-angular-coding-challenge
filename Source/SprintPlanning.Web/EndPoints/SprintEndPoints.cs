using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SprintPlanning.Features.Sprints.Queries;
using SprintPlanning.Features.Sprints.Responses;

namespace SprintPlanning.EndPoints;

public static class SprintEndPoints
{
    public static void MapSprintEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/sprints");

        group.MapGet("", GetSprints);

        group.MapGet("{sprintId:int}", GetSprintDetails);

        group.MapGet("{sprintId:int}/tickets", GetTickets);
    }

    public static async Task<Ok<List<SprintResponse>>> GetSprints(ISender sender,
            CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetSprintsQuery(),
                cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async Task<Results<Ok<SprintResponse>, NotFound<string>>>
        GetSprintDetails(ISender sender,
        int sprintId,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await sender.Send(
                new GetSprintDetailsQuery(sprintId),
                cancellationToken);

            return TypedResults.Ok(response);
        }
        catch
        {
            return TypedResults.NotFound("Sprint not found");
        }
    }

    public static async Task<Ok<List<TicketResponse>>> GetTickets(ISender sender,
         int sprintId,
         CancellationToken cancellationToken)
    {
        var response = await sender.Send(
                new GetSprintTicketsQuery(sprintId),
                cancellationToken);

        return TypedResults.Ok(response);
    }
}
