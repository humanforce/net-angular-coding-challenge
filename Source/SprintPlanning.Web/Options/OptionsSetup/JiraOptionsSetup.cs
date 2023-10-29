using Careview.Scheduling.Web.Options;
using Microsoft.Extensions.Options;

namespace Careview.Scheduling.Web.Common.OptionsSetup;
public class JiraOptionsSetup : IConfigureOptions<JiraOptions>
{
    private readonly IConfiguration _configuration;

    public JiraOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public void Configure(JiraOptions options)
    {
        _configuration.Bind("Apis:Jira", options);
    }
}
