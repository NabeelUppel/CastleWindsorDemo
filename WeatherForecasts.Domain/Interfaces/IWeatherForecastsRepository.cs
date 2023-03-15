using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.Domain.Interfaces
{
    public interface IWeatherForecastsRepository
    {
        WeatherForecast[] GetForecasts();
    }
}
