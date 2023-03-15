using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WeatherForecasts.API.Configs;
using WeatherForecasts.DataAccess.Config;
using WeatherForecasts.DataAccess.MediaRepositories;
using WeatherForecasts.Domain.Abstractions;
using WeatherForecasts.Domain.MediaInterfaces;
using WeatherForecasts.Domain.Models;
using WeatherForecasts.Service.MediaServices;

namespace WeatherForecasts.API.Installers
{
    public class MyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Retrieves connection string from container.
            var connectionStrings = container.Resolve<ConnectionStrings>();

            //DbContext
            //Property for key is the name of the property that is being injected. 
            container.Register(Component.For<AppDbContext>().DependsOn(Property.ForKey("connectionString").Eq(connectionStrings.Default)));

            //Injection into MediaServices into Controllers based on Names
            container.Register(Component.For(typeof(MediaBaseService<Movie>)).ImplementedBy(typeof(MovieService)).Named("MovieService"));
            container.Register(Component.For(typeof(MediaBaseService<TVShow>)).ImplementedBy(typeof(TVShowService)).Named("TVShowService"));


            //Inject Generic MediaRepository into MediaServices... Implicitly figures out the classes?? 
            container.Register(Component.For(typeof(IGenericRepository<>)).ImplementedBy(typeof(GenericRepository<>)));


            // Auto register all classes in the names spaces using conventions
            // Need to register each assembly and namespace
            container.Register(Classes.FromAssemblyNamed("WeatherForecasts.DataAccess")
                .InNamespace("WeatherForecasts.DataAccess.Repositories")
                .WithServiceDefaultInterfaces());

            container.Register(Classes.FromAssemblyNamed("WeatherForecasts.Service")
                .InNamespace("WeatherForecasts.Service.Services")
                .WithServiceDefaultInterfaces());

            container.Register(Classes.FromAssemblyNamed("WeatherForecasts.Domain")
                .InNamespace("WeatherForecasts.Domain.Interfaces")
                .WithServiceDefaultInterfaces());

            // Manual Method
            // container.Register(Component.For<IWeatherForecastsRepository>().ImplementedBy<WeatherForecastsRepository>().LifestyleTransient());
            // container.Register(Component.For<IWeatherForecastsService>().ImplementedBy<WeatherForecastsService>().LifestyleTransient());
        }
    }
}
