using WeatherForecasts.Domain.Abstractions;
using WeatherForecasts.Domain.MediaInterfaces;
using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.Service.MediaServices
{
    public class MovieService : MediaBaseService<Movie>
    {
        public MovieService(IGenericRepository<Movie> repo) : base(repo)
        {

        }
    }
}
