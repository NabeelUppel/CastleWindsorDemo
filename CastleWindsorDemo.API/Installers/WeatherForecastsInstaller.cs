using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CastleWindsorDemo.DataAccess.Repositories;
using CastleWindsorDemo.Domain.Interfaces;
using CastleWindsorDemo.Service.Services;

namespace CastleWindsorDemo.API.Installers
{
    public class WeatherForecastsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Manual Method
            container.Register(Component.For<IWeatherForecastsRepository>().ImplementedBy<WeatherForecastsRepository>().LifestyleTransient());
            container.Register(Component.For<IWeatherForecastsService>().ImplementedBy<WeatherForecastsService>().LifestyleTransient());

            // Auto register all classes in the names spaces using conventions
            // Need to register each assembly and namespace
            container.Register(Classes.FromAssemblyNamed("CastleWindsorDemo.DataAccess")
                .InNamespace("CastleWindsorDemo.DataAccess.Repositories")
                .WithServiceDefaultInterfaces());

            container.Register(Classes.FromAssemblyNamed("CastleWindsorDemo.Service")
                .InNamespace("CastleWindsorDemo.Service.Services")
                .WithServiceDefaultInterfaces());

            container.Register(Classes.FromAssemblyNamed("CastleWindsorDemo.Domain")
                .InNamespace("CastleWindsorDemo.Domain.Interfaces")
                .WithServiceDefaultInterfaces());
        }
    }
}
