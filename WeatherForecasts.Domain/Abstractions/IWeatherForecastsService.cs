using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.Domain.Abstractions
{
    public interface IWeatherForecastsService
    {
        List<WeatherForecast> ProcessFTemprature();
    }
}
