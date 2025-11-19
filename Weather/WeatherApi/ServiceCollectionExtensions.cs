using WeatherApi.WeatherForecastProviders.Abstractions;
using WeatherApi.WeatherForecastProviders.Json;

namespace WeatherApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJsonWeatherForecastProvider(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<WeatherForecastConfig>(
            configuration.GetSection("WeatherForecast")
        );

        services.AddScoped<IWeatherForecastProvider, JsonWeatherForecastProvider>();

        return services;
    }
}