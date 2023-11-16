using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using TeamPlanning.Application.Contracts.Interfaces;
using TeamPlanning.Application.Contracts.Models;
using TeamPlanning.Application.Helper;

namespace TeamPlanning.Application.Services.Real
{
    public class RealBacklogService : IBacklogService
    {
        private readonly string? jiraAPI;
        private readonly string? jiraUsername;
        private readonly string? jiraKey;

        public RealBacklogService(IConfiguration configuration)
        {
            jiraAPI = configuration["JiraAPI"];
            jiraUsername = configuration["JiraUsername"];
            jiraKey = configuration["JiraKey"];
        }
        public async Task<List<Backlog>> GetBySprintId(int sprintId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"{jiraAPI}/api/2/search";
                    var byteArray = Encoding.ASCII.GetBytes($"{jiraUsername}:{jiraKey}");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var payload = new
                    {
                        jql = "Sprint='SCRUM'",
                        maxResults = 1000,
                        startAt = 0
                    };

                    HttpContent content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    response.EnsureSuccessStatusCode();

                    var result = await response.Content.ReadAsStringAsync();
                    JArray values = JSONHelper.ExtractPropertyFromResponse(result, "issues");

                    if (values == null) return null;
                    return values.ToObject<List<Backlog>>()?.Where(c => c.fields.customfield_10020.FirstOrDefault().id == sprintId).ToList(); 
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
