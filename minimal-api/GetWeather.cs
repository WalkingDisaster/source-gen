namespace WalkingDisaster.SourceGenExamples.MinimalApi;

internal class GetWeather
{
    string[] _summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    internal async Task<WeatherForecastResults> GetWeatherFor(string city)
    {
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