using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TeamPlanning.Application.Contracts.Interfaces;
using TeamPlanning.Application.Contracts.Models;
using TeamPlanning.Application.Data.GoogleCalendarAPI;

namespace TeamPlanning.Application.Services.Real
{
    public class RealPublicHolidayService : IPublicHolidayService
    {
        private readonly string? googleCalendarAPIKey;
        public RealPublicHolidayService(IConfiguration configuration)
        {
            googleCalendarAPIKey = configuration["GoogleCalendarAPIKey"];
        }
        public async Task<PublicHoliday> GetByCountryName(string countryName)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string calendarId = CalendarID.calendarIds.Where(c => c.Key.ToLower() == countryName).FirstOrDefault().Value;
                    string apiUrl = $"https://www.googleapis.com/calendar/v3/calendars/{calendarId}/events?key={googleCalendarAPIKey}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    response.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject<PublicHoliday>(await response.Content.ReadAsStringAsync());
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
