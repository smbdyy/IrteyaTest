using WeatherTest.Dto;

namespace WeatherTest.Services;

public interface IWeatherForecastSource
{
    Task<IReadOnlyList<WeatherForecastDto>> GetForecastAsync();
}