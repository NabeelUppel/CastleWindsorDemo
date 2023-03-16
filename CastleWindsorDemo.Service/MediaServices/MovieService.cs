using CastleWindsorDemo.Domain.Abstractions;
using CastleWindsorDemo.Domain.MediaInterfaces;
using CastleWindsorDemo.Domain.Models;

namespace CastleWindsorDemo.Service.MediaServices
{
    public class MovieService : MediaBaseService<Movie>
    {
        public MovieService(IGenericRepository<Movie> repo) : base(repo)
        {

        }
    }
}
