using CastleWindsorDemo.Domain.Interfaces;
using CastleWindsorDemo.Domain.Models;

namespace CastleWindsorDemo.Service.Services
{
    public class WeatherForecastsService : IWeatherForecastsService
    {
        private readonly IWeatherForecastsRepository _weatherForecastRepository;
        public WeatherForecastsService(IWeatherForecastsRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }
        public List<WeatherForecast> ProcessFTemprature()
        {
            var processed = new List<WeatherForecast>();
            var forecasts = _weatherForecastRepository.GetForecasts();
            foreach (var f in forecasts)
            {
                f.TemperatureF = 32 + (int)(f.TemperatureC / 0.5556);
                processed.Add(f);
            }
            return processed;
        }
    }
}
