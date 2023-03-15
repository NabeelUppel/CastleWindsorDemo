using WeatherForecasts.Domain.MediaInterfaces;
using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.Domain.Abstractions
{
    public abstract class MediaBaseService<T> where T : MediaBaseEntity
    {
        private readonly IGenericRepository<T> _genericRepository;

        public MediaBaseService(IGenericRepository<T> repo)
        {
            _genericRepository = repo;
        }

        public async Task<T> Get(int id)
        {
            return await _genericRepository.GetById(id);
        }

        public async Task Insert(T entity)
        {
            if (entity != null)
            {
                await _genericRepository.Insert(entity);
            }
        }

        public async Task Delete(int id)
        {
            await _genericRepository.Delete(id);
        }

        public async Task Update(T entity)
        {
            await _genericRepository.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _genericRepository.GetAll();
        }
    }
}
