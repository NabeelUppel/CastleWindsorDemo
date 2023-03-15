using Microsoft.AspNetCore.Mvc;
using WeatherForecasts.Domain.Abstractions;
using WeatherForecasts.Domain.Interfaces;
using WeatherForecasts.Domain.Models;
using WeatherForecasts.Service.MediaServices;

namespace WeatherForecasts.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TVShowsController : ControllerBase
    {
        private readonly ILogger<TVShowsController> _logger;
        private readonly MediaBaseService<TVShow> _tvShowService;

        public TVShowsController(ILogger<TVShowsController> logger, MediaBaseService<TVShow> tvShowService)
        {
            _logger = logger;
            _tvShowService = tvShowService;
        }


    }
}