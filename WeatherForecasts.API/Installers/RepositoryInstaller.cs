using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WeatherForecasts.DataAccess.Repositories;
using WeatherForecasts.Domain.Interfaces;

namespace WeatherForecasts.API.Installers
{

    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //First Installer
            container.Register(Component.For<IWeatherForecastsRepository>().ImplementedBy<WeatherForecastsRepository>().LifestyleTransient());
        }
    }

}
