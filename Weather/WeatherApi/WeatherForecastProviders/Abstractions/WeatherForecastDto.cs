namespace WeatherApi.WeatherForecastProviders.Abstractions;

public record WeatherForecastDto(DateOnly Date, int TemperatureC, string? Summary);