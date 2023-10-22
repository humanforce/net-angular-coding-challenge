using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.Net;
using System.Net.Http.Headers;
using System.Collections;

namespace Planning;

public class JiraService : IJiraService
{
    // ================================================================================
    // Jira basic auth (e.g. "user@humanforce.com:[key]") is required to call jira api.
    // The credential (_crendential) should be injected in a secure way.
    // Load and return the mock data instead.
    // ================================================================================

    //private const string _sourceUrl = "https://hf-sandbox.atlassian.net";
    //private const string _crendential = "user@humanforce.com:key";
    //private static HttpClient _sharedClient = new()
    //{
    //    BaseAddress = new Uri(_sourceUrl),
    //};

    //public JiraService()
    //{
    //    var byteArray = Encoding.ASCII.GetBytes(_crendential);
    //    _sharedClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
    //        "Basic",
    //        Convert.ToBase64String(byteArray)
    //    );
    //}

    public async Task<string?> GetSprints()
    {
        //var response = await _sharedClient.GetAsync("rest/agile/latest/board/1/sprint");
        //var result = await response.Content.ReadAsStringAsync();
        //return result;

        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, $"Data\\JiraAPI\\sprints.json");
        using var sr = new StreamReader(path);
        var line = await sr.ReadToEndAsync();
        sr.Close();
        return line;
    }

    public async Task<string?> GetBacklog()
    {
//        const string body = @"{
//    ""jql"": ""Sprint='SCRUM'"",
//    ""maxResults"": 1000,
//    ""startAt"": 0
//}";

//        var content = new StringContent(body, Encoding.UTF8, "application/json");
//        var response = await _sharedClient.PostAsync("rest/api/2/search", content);
//        var result = await response.Content.ReadAsStringAsync();
//        return result;

        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, $"Data\\JiraAPI\\backlog.json");
        using var sr = new StreamReader(path);
        var line = await sr.ReadToEndAsync();
        sr.Close();
        return line;
    }
}
