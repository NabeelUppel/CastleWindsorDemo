﻿using WeatherForecasts.Domain.Abstractions;
using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.Service.Services
{
    public class WeatherForescastsService : IWeatherForecastsService
    {
        private readonly IWeatherForecastsRepository _weatherForecastRepository;
        public WeatherForescastsService(IWeatherForecastsRepository weatherForecastRepository)
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