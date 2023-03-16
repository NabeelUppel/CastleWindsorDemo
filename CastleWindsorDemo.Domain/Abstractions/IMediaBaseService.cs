using CastleWindsorDemo.Domain.Models;

namespace CastleWindsorDemo.Domain.Abstractions
{
    public interface IMediaBaseService<T> where T : MediaBaseEntity
    {
        Task Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Insert(T entity);
        Task Update(T entity);
    }
}