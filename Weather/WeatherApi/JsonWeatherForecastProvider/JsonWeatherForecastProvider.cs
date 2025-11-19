using Microsoft.Extensions.Options;
using WeatherApi.WeatherForecastProvider;

namespace WeatherApi.JsonWeatherForecastProvider;

public class JsonWeatherForecastProvider : IWeatherForecastProvider
{
    private readonly IOptionsMonitor<WeatherForecastConfig> _weatherForecastConfig;

    public JsonWeatherForecastProvider(IOptionsMonitor<WeatherForecastConfig> weatherForecastConfig)
    {
        _weatherForecastConfig = weatherForecastConfig;
    }
    
    public IReadOnlyList<WeatherForecastDto> GetForecast()
        => _weatherForecastConfig.CurrentValue.WeatherForecast;
}