namespace BlazorWeather.WeatherForecastSource.Abstractions;

public record WeatherForecastDto(DateOnly Date, int TemperatureC, string? Summary);