using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CastleWindsorDemo.API.Configs;
using CastleWindsorDemo.DataAccess.Config;
using CastleWindsorDemo.DataAccess.MediaRepositories;
using CastleWindsorDemo.Domain.Abstractions;
using CastleWindsorDemo.Domain.MediaInterfaces;
using CastleWindsorDemo.Domain.Models;
using CastleWindsorDemo.Service.MediaServices;

namespace CastleWindsorDemo.API.Installers
{
    public class MediaInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Retrieves connection string from container.
            var connectionStrings = container.Resolve<ConnectionStrings>();

            //DbContext
            //Property for key is the name of the property that is being injected. 
            container.Register(Component.For<AppDbContext>().DependsOn(Property.ForKey("connectionString").Eq(connectionStrings.Default)));

            //Injection into MediaServices into Controllers based on Names
            container.Register(Component.For(typeof(IMediaBaseService<>)).ImplementedBy(typeof(MediaBaseService<>)));


            //Inject Generic MediaRepository into MediaServices... Implicitly figures out the classes?? 
            container.Register(Component.For(typeof(IGenericRepository<>)).ImplementedBy(typeof(GenericRepository<>)));
        }
    }
}
