using System.Text.Json;
using TeamPlanning.Application.Contracts.Interfaces;
using TeamPlanning.Application.Contracts.Models;

namespace TeamPlanning.Application.Services.Mock
{
    public class MockSprintService : ISprintService
    {
        public string parentDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory());
        public string relativeSprintMockFilePath = "TeamPlanning.Application\\Data\\JiraAPI\\sprints.json";

        public Task<List<Sprint>> GetAll()
        {
            string sprintMockFilePath = Path.Combine(parentDirectory, this.relativeSprintMockFilePath);
            string jsonString = "";
            try
            {
                jsonString = File.ReadAllText(sprintMockFilePath);

            } catch(Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
            }

            if (!string.IsNullOrEmpty(jsonString))
            {
                var jsonObject = JsonDocument.Parse(jsonString).RootElement;
                if (jsonObject.TryGetProperty("values", out var valuesElement))
                {
                    List<Sprint> sprints = JsonSerializer.Deserialize<List<Sprint>>(valuesElement.GetRawText());
                    return Task.FromResult(sprints ?? new List<Sprint>());
                }
            }

            return Task.FromResult(new List<Sprint>());
        }
    }
}