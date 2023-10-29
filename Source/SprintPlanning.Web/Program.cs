using SprintPlanning.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        builder.Services
            .ConfigureSetupOptions()
            .ConfigureServices();

        builder.Services
        .AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        }).AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<Program>();
        }).AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

        }

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseCors("AllowLocalhost");

        app.MapApis();

        app.Run();
    }
}