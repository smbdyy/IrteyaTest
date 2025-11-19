using System.Net.Http.Json;
using WeatherTest.Dto;

namespace WeatherTest.Services;

public class HttpWeatherForecastSource : IWeatherForecastSource
{
    private readonly HttpClient _client;
    private readonly string _baseAddress;

    public HttpWeatherForecastSource(HttpClient client, string baseAddress)
    {
        _client = client;
        _baseAddress = baseAddress;
    }

    public async Task<IReadOnlyList<WeatherForecastDto>> GetForecastAsync()
    {
        var url = $"{_baseAddress}/api/weather";
        var result = await _client.GetFromJsonAsync<WeatherForecastDto[]>(url);
        return result ?? Array.Empty<WeatherForecastDto>();
    }
}