using Microsoft.AspNetCore.Mvc;
using CastleWindsorDemo.Domain.Abstractions;
using CastleWindsorDemo.Domain.Interfaces;
using CastleWindsorDemo.Domain.Models;
using CastleWindsorDemo.Service.MediaServices;

namespace CastleWindsorDemo.API.Controllers
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