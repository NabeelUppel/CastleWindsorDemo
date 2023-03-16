using CastleWindsorDemo.Domain.Models;

namespace CastleWindsorDemo.Domain.MediaInterfaces
{
    public interface IGenericRepository<T> where T : MediaBaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
