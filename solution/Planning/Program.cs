using Planning;

var AllowedOrigins = "_AllowedOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: AllowedOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:44448");
            policy.WithOrigins("http://localhost:4200");
        }
    );
});

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICalendarService, CalendarService>();
builder.Services.AddSingleton<IJiraService, JiraService>();

var app = builder.Build();

app.UseCors(AllowedOrigins);

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
