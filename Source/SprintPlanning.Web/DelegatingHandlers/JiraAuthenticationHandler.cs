using Careview.Scheduling.Web.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace SprintPlanning.DelegatingHandlers;

public sealed class JiraAuthenticationHandler : DelegatingHandler
{
    private readonly JiraOptions _jiraOptions;
    public JiraAuthenticationHandler(IOptions<JiraOptions> jiraOptions)
    {
        _jiraOptions = jiraOptions.Value;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {

        request.Headers.Authorization = new AuthenticationHeaderValue(
            "Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes(_jiraOptions.Authorization)));
        return base.SendAsync(request, cancellationToken);
    }
}
