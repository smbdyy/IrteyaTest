using WeatherApi.WeatherForecastProviders.Abstractions;

namespace WeatherApi.WeatherForecastProviders.Json;

public class WeatherForecastConfig
{
    public IReadOnlyList<WeatherForecastDto> WeatherForecast { get; set; }
}