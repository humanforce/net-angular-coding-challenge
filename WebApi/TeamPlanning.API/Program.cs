using TeamPlanning.Application.Contracts.Interfaces;
using TeamPlanning.Application.Services.Mock;
using TeamPlanning.Application.Services.Real;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var test = builder.Configuration.GetSection("UseMockService");

if (builder.Configuration.GetSection("UseMockService").Value.ToLower().Equals("true"))
{
    builder.Services.AddSingleton<ISprintService, MockSprintService>();
    builder.Services.AddSingleton<ITeamMemberService, MockTeamMemberService>();
    builder.Services.AddSingleton<IBacklogService, MockBacklogService>();
    builder.Services.AddSingleton<IPublicHolidayService, MockPublicHolidayService>();
}
else
{
    builder.Services.AddSingleton<ISprintService, RealSprintService>();
    builder.Services.AddSingleton<ITeamMemberService, MockTeamMemberService>(); //RealTeamMemberService > no available API for team member
    builder.Services.AddSingleton<IBacklogService, RealBacklogService>();
    builder.Services.AddSingleton<IPublicHolidayService, RealPublicHolidayService>();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
