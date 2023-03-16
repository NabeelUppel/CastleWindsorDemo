using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CastleWindsorDemo.DataAccess.Repositories;
using CastleWindsorDemo.Domain.Interfaces;

namespace CastleWindsorDemo.API.Installers
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
