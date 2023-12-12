namespace WalkingDisaster.SourceGenExamples.MinimalApi;

internal readonly record struct WeatherForecastResults(string City, WeatherForecast[] Forecast){}