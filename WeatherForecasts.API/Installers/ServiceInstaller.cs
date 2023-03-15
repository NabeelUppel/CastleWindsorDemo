using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WeatherForecasts.Domain.Interfaces;
using WeatherForecasts.Service.Services;

namespace WeatherForecasts.API.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IWeatherForecastsService>().ImplementedBy<WeatherForecastsService>().LifestyleTransient());
        }
    }
}
