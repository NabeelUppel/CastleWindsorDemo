using Microsoft.AspNetCore.Mvc;
using CastleWindsorDemo.API.DTOs;
using CastleWindsorDemo.Domain.Abstractions;
using CastleWindsorDemo.Domain.Models;

namespace CastleWindsorDemo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly MediaBaseService<Movie> _movieService;

        public MoviesController(ILogger<MoviesController> logger, MediaBaseService<Movie> movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            try
            {
                var result = await _movieService.Get(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<Movie>> InsertMovie([FromBody] AddMovieDTO movieDTO)
        {
            try
            {
                var movie = new Movie();
                movie.Title = movieDTO.Title;
                movie.Year = movieDTO.Year;
                movie.RunTime = movieDTO.RunTime;
                await _movieService.Insert(movie);
                return new JsonResult("Movie Added" ) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult("Something Went wrong:" + e) { StatusCode = 500 };
            }
                       
        }

        [HttpDelete("remove")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            try
            {
                await _movieService.Delete(id);
                return new JsonResult("Movie Deleted") { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult("Something Went wrong:" + e) { StatusCode = 500 };
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<Movie>> UpdateMovie([FromBody] UpdateMovieDTO movieDTO)
        {
            try
            {
                var movie = new Movie();
                movie.Title = movieDTO.Title;
                movie.Year = movieDTO.Year;
                movie.RunTime = movieDTO.RunTime;
                movie.Id = movieDTO.Id;
                await _movieService.Update(movie);
                return new JsonResult("Movie Updated") { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult("Something Went wrong:" + e) { StatusCode = 500 };
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<Movie>> GetAll()
        {
            try
            {
                var all = await _movieService.GetAll();
                return new JsonResult(all) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult("Something Went wrong:" + e) { StatusCode = 500 };
            }
        }
    }
}
