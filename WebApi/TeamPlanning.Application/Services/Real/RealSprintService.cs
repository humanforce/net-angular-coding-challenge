using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Text;
using TeamPlanning.Application.Contracts.Interfaces;
using TeamPlanning.Application.Contracts.Models;
using TeamPlanning.Application.Helper;

namespace TeamPlanning.Application.Services.Real
{
    public class RealSprintService : ISprintService
    {
        private readonly string? jiraAPI;
        private readonly string? jiraUsername;
        private readonly string? jiraKey;
        public RealSprintService(IConfiguration configuration) 
        {
            jiraAPI = configuration["JiraAPI"];
            jiraUsername = configuration["JiraUsername"];
            jiraKey = configuration["JiraKey"];
        }
        public async Task<List<Sprint>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var byteArray = Encoding.ASCII.GetBytes($"{jiraUsername}:{jiraKey}");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    string apiUrl = $"{jiraAPI}/agile/latest/board/1/sprint";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    var result = await response.Content.ReadAsStringAsync();
                    JArray values = JSONHelper.ExtractPropertyFromResponse(result, "values");
                    if (values == null) return null;
                    return values.ToObject<List<Sprint>>(); 
                  
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
