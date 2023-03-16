using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CastleWindsorDemo.Domain.Interfaces;
using CastleWindsorDemo.Service.Services;

namespace CastleWindsorDemo.API.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IWeatherForecastsService>().ImplementedBy<WeatherForecastsService>().LifestyleTransient());
        }
    }
}
