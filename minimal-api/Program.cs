using System.Text.Json;
using WalkingDisaster.SourceGenExamples.MinimalApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(x => x.AddSimpleConsole());

builder.Services
    .ConfigureHttpJsonOptions(opt =>
    {
        opt.SerializerOptions.TypeInfoResolverChain.Insert(0, SourceGenerationContext.Default);
    });
builder.Services.AddSingleton<GetWeather>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/weatherforecast", async (GetWeather service) => await service.GetWeatherFor("Generic").ConfigureAwait(false));
app.MapPost("/weatherforecast", async (GetWeather service, WeatherForecastRequest request) => await service.GetWeatherFor(request.City).ConfigureAwait(false));

app.Run();