using System.Text.Json;
using TeamPlanning.Application.Contracts.Interfaces;
using TeamPlanning.Application.Contracts.Models;

namespace TeamPlanning.Application.Services.Mock
{
    public class MockPublicHolidayService : IPublicHolidayService
    {
        public string parentDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory());
        public string relativePublicHolidayMockFilePath = "TeamPlanning.Application\\Data\\GoogleCalendarAPI";
        public Task<PublicHoliday> GetByCountryName(string countryName)
        {
            string publicHolidayMockDirectory = Path.Combine(parentDirectory, this.relativePublicHolidayMockFilePath);
            string[] jsonFiles = Directory.GetFiles(publicHolidayMockDirectory, "*.json");

            List<PublicHoliday> allPublicHolidays = new List<PublicHoliday>();

            foreach (var jsonFile in jsonFiles)
            {
                try
                {
                    string jsonString = File.ReadAllText(jsonFile);

                    if (!string.IsNullOrEmpty(jsonString))
                    {
                        PublicHoliday publicHolidays = JsonSerializer.Deserialize<PublicHoliday>(jsonString);
                        allPublicHolidays.Add(publicHolidays);
                    }
                }
                catch
                {
                    return null;
                }
            }

            return Task.FromResult(allPublicHolidays.Where(p => p.summary.ToLower().Contains(countryName.ToLower())).SingleOrDefault());
        }
    }
}
