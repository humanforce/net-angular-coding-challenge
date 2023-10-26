using Planning.Models;
using System.Reflection;

namespace Planning;

public class CalendarService : ICalendarService
{
    // ================================================================================
    // Google Api key (events?key=) is required to call the calendar api.
    // The key (_apiKey) should be injected in a secure way.
    // Load and return the mock data instead.
    // ================================================================================

    //private const string _apiKey = "";
    //private const string _sourceUrl = "https://www.googleapis.com";
    //private const string _calendayUrl = "calendar/v3/calendars/{0}/events?key={1}";
    //private static HttpClient _sharedClient = new()
    //{
    //    BaseAddress = new Uri(_sourceUrl),
    //};

    public async Task<string?> GetPublicHolidays(Region region)
    {
        //var source = region switch
        //{
        //    Region.australian => "en.australian%23holiday%40group.v.calendar.google.com",
        //    Region.pakistan => "en.pk%23holiday%40group.v.calendar.google.com",
        //    Region.philippines => "en.philippines%23holiday%40group.v.calendar.google.com",
        //    _ => throw new InvalidDataException(nameof(region)),
        //};
        //var response = await _sharedClient.GetAsync(string.Format(_calendayUrl, source, _apiKey));
        //var result = await response.Content.ReadAsStringAsync();
        //return result;

        var source = region switch
        {
            Region.australian => "australian.json",
            Region.pakistan => "pakistan.json",
            Region.philippines => "philippines.json",
            _ => null,
        };

        if (source == null)
            return null;

        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, $"Data\\GoogleCalendarAPI\\{source}");
        using var sr = new StreamReader(path);
        var line = await sr.ReadToEndAsync();
        sr.Close();
        return line;
    }
}
