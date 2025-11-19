using BlazorWeather.WeatherForecastSource.Abstractions;
using BlazorWeather.WeatherForecastSource.Http;

namespace BlazorWeather;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHttpWeatherForecastSource(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<WeatherApiOptions>(
            configuration.GetSection(WeatherApiOptions.SectionName)
        );

        services.AddScoped<HttpClient>();
        services.AddScoped<IWeatherForecastSource, HttpWeatherForecastSource>();
        
        return services;
    }
}