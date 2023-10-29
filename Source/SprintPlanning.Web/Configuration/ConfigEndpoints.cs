using SprintPlanning.EndPoints;

namespace SprintPlanning.Configuration;

public static class ConfigEndpoints
{
    public static void MapApis(this IEndpointRouteBuilder app)
    {
        app.MapSprintEndPoints();
        app.MapTeamMemberEndPoints();
    }
}
