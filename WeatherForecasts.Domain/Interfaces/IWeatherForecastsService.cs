using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.Domain.Interfaces
{
    public interface IWeatherForecastsService
    {
        List<WeatherForecast> ProcessFTemprature();
    }
}
