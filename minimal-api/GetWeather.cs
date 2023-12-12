namespace WalkingDisaster.SourceGenExamples.MinimalApi;

internal class GetWeather
{
    private readonly ILogger<GetWeather> _logger;

    string[] _summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public GetWeather(ILogger<GetWeather> logger)
    {
        _logger = logger;
    }

    internal async Task<WeatherForecastResults> GetWeatherFor(string city)
    {
        GetWeatherClassLogging.GetForCity(_logger, city);

        return await Task.FromResult(new WeatherForecastResults(
            city,
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                _summaries[Random.Shared.Next(_summaries.Length)]
            )).ToArray())).ConfigureAwait(false);
    }
}

internal static partial class GetWeatherClassLogging
{
    [LoggerMessage(1, LogLevel.Information, "Getting weather for city {city}", EventName = "GetWeatherForCity")]
    internal static partial void GetForCity(ILogger logger, string city);
}