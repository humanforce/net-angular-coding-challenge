using System.Text.Json;
using TeamPlanning.Application.Contracts.Interfaces;
using TeamPlanning.Application.Contracts.Models;

namespace TeamPlanning.Application.Services.Mock
{
    public class MockBacklogService : IBacklogService
    {
        public string parentDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory());
        public string relativeBacklogMockFilePath = "TeamPlanning.Application\\Data\\JiraAPI\\backlog.json";
        public Task<List<Backlog>> GetBySprintId(int sprintId)
        {
            string backlogMockFilePath = Path.Combine(parentDirectory, this.relativeBacklogMockFilePath);
            string jsonString = "";
            try
            {
                jsonString = File.ReadAllText(backlogMockFilePath);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
            }

            if (!string.IsNullOrEmpty(jsonString))
            {
                var jsonObject = JsonDocument.Parse(jsonString).RootElement;
                if (jsonObject.TryGetProperty("issues", out var valuesElement))
                {
                    List<Backlog> backlogs = JsonSerializer.Deserialize<List<Backlog>>(valuesElement.GetRawText());
                    return Task.FromResult(backlogs.Where(b => b.fields.customfield_10020.FirstOrDefault().id == sprintId).ToList() ?? new List<Backlog>());
                }
            }

            return Task.FromResult(new List<Backlog>());
        }
    }
}
