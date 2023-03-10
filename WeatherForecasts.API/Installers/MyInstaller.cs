using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WeatherForecasts.DataAccess.Repositories;
using WeatherForecasts.Domain.Abstractions;
using WeatherForecasts.Service.Services;

namespace WeatherForecasts.API.Installers
{
    public class MyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IWeatherForecastsRepository>().ImplementedBy<WeatherForecastsRepository>().LifestyleTransient());
            container.Register(Component.For<IWeatherForecastsService>().ImplementedBy<WeatherForescastsService>().LifestyleTransient());
        }
    }
}
