namespace SprintPlanning.Features.Teams.Responses;

public sealed class TeamMemberCapacityResponse
{
    public string Name { get; private set; }

    public string Country { get; private set; }
    public double Capacity { get; private set; }
    private const int _workingDays = 10;
    private const double _workingHours = 7.5;
    public TeamMemberCapacityResponse(string name,
        string countryName,
        int offDays)
    {
        Name = name;
        Country = countryName;
        Capacity = (_workingDays - offDays) * _workingHours;
    }

}
