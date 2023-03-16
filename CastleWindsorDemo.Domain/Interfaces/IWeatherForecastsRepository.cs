using CastleWindsorDemo.Domain.Models;

namespace CastleWindsorDemo.Domain.Interfaces
{
    public interface IWeatherForecastsRepository
    {
        WeatherForecast[] GetForecasts();
    }
}
