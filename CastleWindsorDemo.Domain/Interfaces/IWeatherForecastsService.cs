using CastleWindsorDemo.Domain.Models;

namespace CastleWindsorDemo.Domain.Interfaces
{
    public interface IWeatherForecastsService
    {
        List<WeatherForecast> ProcessFTemprature();
    }
}
