using Microsoft.EntityFrameworkCore;
using WeatherForecasts.DataAccess.Config;
using WeatherForecasts.Domain.Exceptions;
using WeatherForecasts.Domain.MediaInterfaces;
using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.DataAccess.MediaRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : MediaBaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> table;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            table = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await table.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public Task Update(T entity)
        {
            var find = table.Find(entity.Id);
            if (find == null)
            {
                throw new NotFoundException("id:" + entity.Id);
            }
            
            find.Title = entity.Title;
            find.Year = entity.Year;
            
            if(typeof(T) == typeof(Movie))
            {
                Movie m = (Movie) Convert.ChangeType(find, typeof(Movie));
                Movie e = (Movie)Convert.ChangeType(entity, typeof(Movie));
                m.RunTime = e.RunTime;
            }

            if (typeof(T) == typeof(TVShow))
            {
                TVShow m = (TVShow)Convert.ChangeType(find, typeof(TVShow));
                TVShow e = (TVShow)Convert.ChangeType(entity, typeof(TVShow));
                m.TotalEpisodes = e.TotalEpisodes;
                m.Seasons= e.Seasons;
            }

            return _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            var entity =  table.Find(id);
            if(entity == null)
            {
                throw new NotFoundException("id:" + id);
            }
            table.Remove(entity);
            return _context.SaveChangesAsync();
        }
    }
}
