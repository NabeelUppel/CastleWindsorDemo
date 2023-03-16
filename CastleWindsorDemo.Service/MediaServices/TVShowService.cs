using CastleWindsorDemo.Domain.Abstractions;
using CastleWindsorDemo.Domain.MediaInterfaces;
using CastleWindsorDemo.Domain.Models;

namespace CastleWindsorDemo.Service.MediaServices
{
    public class TVShowService : MediaBaseService<TVShow>
    {
        public TVShowService(IGenericRepository<TVShow> repo) : base(repo)
        {

        }
    }
}
