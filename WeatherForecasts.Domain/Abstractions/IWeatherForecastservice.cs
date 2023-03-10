using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.Domain.Abstractions
{
    public interface IWeatherForecastService
    {
        List<WeatherForecast> ProcessFTemprature();
    }
}
