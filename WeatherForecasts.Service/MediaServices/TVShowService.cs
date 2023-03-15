using WeatherForecasts.Domain.Abstractions;
using WeatherForecasts.Domain.MediaInterfaces;
using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.Service.MediaServices
{
    public class TVShowService : MediaBaseService<TVShow>
    {
        public TVShowService(IGenericRepository<TVShow> repo) : base(repo)
        {

        }
    }
}
