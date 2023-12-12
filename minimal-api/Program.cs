using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using WalkingDisaster.SourceGenExamples.MinimalApi;

var builder = WebApplication.CreateBuilder(args);
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

app.MapPost("/weatherforecast2", async (GetWeather service, HttpRequest request) =>
{
    var req = await JsonSerializer.DeserializeAsync(request.Body, SourceGenerationContext.Default.WeatherForecastRequest).ConfigureAwait(false);
    var result = await service.GetWeatherFor(req.City).ConfigureAwait(false);
    return JsonContent.Create(JsonSerializer.Serialize(result, SourceGenerationContext.Default.WeatherForecastResults));
});

app.Run();