using System.Text.Json;
using TeamPlanning.Application.Contracts.Interfaces;
using TeamPlanning.Application.Contracts.Models;

namespace TeamPlanning.Application.Services.Mock
{
    public class MockTeamMemberService : ITeamMemberService
    {
        public string parentDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory());
        public string relativeTeamMemberMockFilePath = "TeamPlanning.Application\\Data\\TeamMembers.json";
        public Task<List<TeamMember>> GetAll()
        {
            string teamMemberMockFilePath = Path.Combine(parentDirectory, this.relativeTeamMemberMockFilePath);
            string jsonString = "";
            try
            {
                jsonString = File.ReadAllText(teamMemberMockFilePath);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
            }

            if (!string.IsNullOrEmpty(jsonString))
            {
                List<TeamMember> teamMembers = JsonSerializer.Deserialize<List<TeamMember>>(jsonString);
                return Task.FromResult(teamMembers ?? new List<TeamMember>());
            }

            return Task.FromResult(new List<TeamMember>()); 
        }
    }
}
