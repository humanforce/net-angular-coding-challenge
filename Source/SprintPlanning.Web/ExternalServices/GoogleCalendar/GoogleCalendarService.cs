using Careview.Scheduling.Web.Options;
using Microsoft.Extensions.Options;
using SprintPlanning.Common;
using SprintPlanning.Common.Extensions;
using SprintPlanning.Common.Services;
using SprintPlanning.ExternalServices.GoogleCalendar.Enums;
using SprintPlanning.ExternalServices.GoogleCalendar.Models;

namespace SprintPlanning.ExternalServices.GoogleCalendar;

public sealed class GoogleCalendarService : IGoogleCalendarService
{
    private readonly HttpClient _httpClient;
    private readonly GoogleCalendarOptions _googleCalendarOptions;
    private readonly ILogger<GoogleCalendarService> _logger;
    private readonly Dictionary<Countries, (string endpoint, string jsonFileName)> _countryMappings;
    private readonly IJsonDataLoader _jsonDataLoader;
    public GoogleCalendarService(
        IHttpClientFactory httpClientFactory,
        IOptions<GoogleCalendarOptions> googleCalendarOptions,
        ILogger<GoogleCalendarService> logger,
        IJsonDataLoader jsonDataLoader)
    {
        _httpClient = httpClientFactory.CreateClient(Constants.HttpClientGoogleCalendar);
        _logger = logger;
        _googleCalendarOptions = googleCalendarOptions.Value;

        // Define country-specific endpoint and JSON file name mappings
        _countryMappings = new Dictionary<Countries, (string, string)>
        {
            { Countries.Australia, (_googleCalendarOptions.AustralianEndPoint, "australian.json") },
            { Countries.Pakistan, (_googleCalendarOptions.PakistanEndPoint, "pakistan.json") },
            { Countries.Philippines, (_googleCalendarOptions.PhilippinesEndPoint, "philippines.json") },
        };
        _jsonDataLoader = jsonDataLoader;
    }

    public async Task<CalendarEvent> GetCalendarEvent(Countries country, CancellationToken cancellationToken)
    {
        _countryMappings.TryGetValue(country, out var result);

        CalendarEvent @event;
        try
        {
            @event = await _httpClient.GetAsync<CalendarEvent>(result.endpoint, cancellationToken);
            if (@event == null)
            {
                throw new InvalidOperationException("");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred: {ErrorMessage}", ex.Message);
            @event = await RetrieveSeedData(result.jsonFileName, cancellationToken);
        }

        return @event;
    }

    private async Task<CalendarEvent> RetrieveSeedData(
        string fileName,
        CancellationToken cancellationToken)
    {
        var jsonFilePath = Path.Combine("wwwroot/Data/GoogleCalendarAPI", fileName);

        return await _jsonDataLoader.LoadAsync<CalendarEvent>(jsonFilePath, cancellationToken);
    }
}


