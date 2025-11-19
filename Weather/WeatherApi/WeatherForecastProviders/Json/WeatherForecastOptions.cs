using WeatherApi.WeatherForecastProviders.Abstractions;

namespace WeatherApi.WeatherForecastProviders.Json;

public class WeatherForecastOptions
{
    public const string SectionName = "WeatherForecast";
    
    public IReadOnlyList<WeatherForecastDto> WeatherForecast { get; set; }
}