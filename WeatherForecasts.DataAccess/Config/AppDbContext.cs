using Microsoft.EntityFrameworkCore;
using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.DataAccess.Config
{
    public class AppDbContext : DbContext
    {
        private readonly string connectionString;
        public AppDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TVShow>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<TVShow> TVShows { get; set; }
    }
}