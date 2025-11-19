namespace WeatherApi.WeatherForecastProvider;

public record WeatherForecastDto(DateOnly Date, int TemperatureC, string? Summary);