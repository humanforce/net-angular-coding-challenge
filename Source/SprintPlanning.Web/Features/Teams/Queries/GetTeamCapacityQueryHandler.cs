using MediatR;
using SprintPlanning.Common.Services;
using SprintPlanning.ExternalServices.GoogleCalendar.Enums;
using SprintPlanning.Features.Sprints.Queries;
using SprintPlanning.Features.Teams.Models;
using SprintPlanning.Features.Teams.Responses;

namespace SprintPlanning.Features.Teams.Queries;

public class GetTeamCapacityQueryHandler : IRequestHandler<GetTeamCapacityQuery, List<TeamMemberCapacityResponse>>
{
    private readonly IJsonDataLoader _jsonDataLoader;
    private readonly ISender _sender;
    public GetTeamCapacityQueryHandler(
        IJsonDataLoader jsonDataLoader,
        ISender sender)
    {
        _jsonDataLoader = jsonDataLoader;
        _sender = sender;
    }


    public async Task<List<TeamMemberCapacityResponse>> Handle(GetTeamCapacityQuery request, CancellationToken cancellationToken)
    {
        var teamMembers = await LoadTeamMembersAsync(cancellationToken);
        var holidays = await _sender.Send
            (new GetPublicHolidaysQuery(
            request.StartDate,
            request.StartDate.AddDays(14)),
            cancellationToken);

        var (australiaOffDays, pakistanOffDays, philippinesOffDays) = CalculateOffDays(
            holidays);

        var teamMembersCapacity = CalculateTeamMembersCapacity(
            teamMembers,
            australiaOffDays,
            pakistanOffDays,
            philippinesOffDays);

        return teamMembersCapacity;
    }

    private async Task<List<Person>> LoadTeamMembersAsync(CancellationToken cancellationToken)
    {
        return await _jsonDataLoader.LoadAsync<List<Person>>(
            "wwwroot/Data/TeamMembers.json",
            cancellationToken);
    }

    private static (int australiaOffDays, int pakistanOffDays, int philippinesOffDays) CalculateOffDays(
        List<PublicHolidayResponse> publicHolidays)
    {
        int australiaOffDays = publicHolidays
            .Where(h => h.Country == Countries.Australia)
            .Count();

        int pakistanOffDays = publicHolidays
            .Where(h => h.Country == Countries.Pakistan)
               .Count();

        int philippinesOffDays = publicHolidays
            .Where(h => h.Country == Countries.Philippines)
            .Count();

        return (australiaOffDays, pakistanOffDays, philippinesOffDays);
    }

    private static List<TeamMemberCapacityResponse> CalculateTeamMembersCapacity(
        List<Person> teamMembers,
        int australiaOffDays,
        int pakistanOffDays,
        int philippinesOffDays)
    {
        var teamMembersCapacity = new List<TeamMemberCapacityResponse>();

        foreach (var teamMember in teamMembers)
        {
            var offDays = teamMember.Location.Country switch
            {
                "Australia" => australiaOffDays,
                "Pakistan" => pakistanOffDays,
                "Philippines" => philippinesOffDays,
                _ => throw new ArgumentException("Invalid Country")
            };

            teamMembersCapacity.Add(new TeamMemberCapacityResponse(teamMember.Name,
                teamMember.Location.Country,
                offDays));
        }

        return teamMembersCapacity;
    }
}
