using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentAssertions.Types;
using Microsoft.VisualBasic;
using System.Diagnostics;
using WeatherForecasts.DataAccess.Repositories;
using WeatherForecasts.Domain.Abstractions;
using WeatherForecasts.Service.Services;

namespace WeatherForecasts.API.Installers
{
    public class MyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //First Installer
            //container.Register(Component.For<IWeatherForecastsRepository>().ImplementedBy<WeatherForecastsRepository>().LifestyleTransient());
            //container.Register(Component.For<IWeatherForecastsService>().ImplementedBy<WeatherForecastsService>().LifestyleTransient());


            // Need to register each assembly and namespace
            container.Register(Classes.FromAssemblyNamed("WeatherForecasts.DataAccess")
                .InNamespace("WeatherForecasts.DataAccess.Repositories")
                .WithServiceDefaultInterfaces());

            container.Register(Classes.FromAssemblyNamed("WeatherForecasts.Service")
                .InNamespace("WeatherForecasts.Service.Services")
                .WithServiceDefaultInterfaces());

            container.Register(Classes.FromAssemblyNamed("WeatherForecasts.Domain")
                .InNamespace("WeatherForecasts.Domain.Abstractions")
                .WithServiceDefaultInterfaces());

                
        }
    }
}
