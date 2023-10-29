using Careview.Scheduling.Web.Options;
using Microsoft.Extensions.Options;

namespace Careview.Scheduling.Web.Common.OptionsSetup;
public class GoogleCalendarOptionsSetup : IConfigureOptions<GoogleCalendarOptions>
{
    private readonly IConfiguration _configuration;

    public GoogleCalendarOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public void Configure(GoogleCalendarOptions options)
    {
        _configuration.Bind("Apis:GoogleCalendar", options);
    }
}
