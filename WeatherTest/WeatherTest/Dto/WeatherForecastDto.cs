namespace WeatherTest.Dto;

public record WeatherForecastDto(DateOnly Date, int TemperatureC, string? Summary);