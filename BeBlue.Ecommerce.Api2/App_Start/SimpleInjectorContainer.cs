using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

using BeBlue.Ecommerce.Servico;
using BeBlue.Ecommerce.Servico.Interface;

namespace BeBlue.Ecommerce.Api2.App_Start
{
    public static class SimpleInjectorContainer
    {
        public static void RegisterServices()
        {

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IAlbumService, AlbumService>(Lifestyle.Scoped);
            container.Register<IPrecoService, PrecoService>(Lifestyle.Scoped);
            container.Register<IVendaService, VendaService>(Lifestyle.Scoped);
            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);


            container.Verify();

            //return container;


        }
    }
}