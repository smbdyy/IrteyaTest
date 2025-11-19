using WeatherApi.WeatherForecastProviders.Abstractions;

namespace WeatherApi.WeatherForecastProviders.Json;

public record WeatherForecastConfig(IReadOnlyList<WeatherForecastDto> WeatherForecast);