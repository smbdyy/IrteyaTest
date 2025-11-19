namespace BlazorWeather.WeatherForecastSource.Abstractions;

public interface IWeatherForecastSource
{
    Task<IReadOnlyList<WeatherForecastDto>> GetForecastAsync();
}