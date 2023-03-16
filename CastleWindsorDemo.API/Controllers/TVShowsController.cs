using Microsoft.AspNetCore.Mvc;
using CastleWindsorDemo.Domain.Abstractions;
using CastleWindsorDemo.Domain.Models;

namespace CastleWindsorDemo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TVShowsController : ControllerBase
    {
        private readonly ILogger<TVShowsController> _logger;
        private readonly IMediaBaseService<TVShow> _tvShowService;

        public TVShowsController(ILogger<TVShowsController> logger, IMediaBaseService<TVShow> tvShowService)
        {
            _logger = logger;
            _tvShowService = tvShowService;
        }


    }
}