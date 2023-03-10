using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.Domain.Abstractions
{
    public interface IWeatherForecastsRepository
    {
        WeatherForecast[] GetForecasts();
    }
}
