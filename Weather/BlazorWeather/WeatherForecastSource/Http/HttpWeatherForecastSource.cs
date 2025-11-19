using BlazorWeather.WeatherForecastSource.Abstractions;
using Microsoft.Extensions.Options;

namespace BlazorWeather.WeatherForecastSource.Http;

public class HttpWeatherForecastSource : IWeatherForecastSource
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAddress;

    public HttpWeatherForecastSource(HttpClient httpClient, IOptions<WeatherApiOptions> options)
    {
        _httpClient = httpClient;
        _baseAddress = options.Value.BaseAddress;
    }

    public async Task<IReadOnlyList<WeatherForecastDto>> GetForecastAsync()
    {
        var url = $"{_baseAddress}/api/weather";
        var forecasts = await _httpClient.GetFromJsonAsync<WeatherForecastDto[]>(url);
        return forecasts ?? Array.Empty<WeatherForecastDto>();
    }
}