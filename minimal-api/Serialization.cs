using System.Text.Json.Serialization;

namespace WalkingDisaster.SourceGenExamples.MinimalApi;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(WeatherForecastRequest))]
[JsonSerializable(typeof(WeatherForecastResults))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
