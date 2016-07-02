using BusStop.API.App_Start;
using NServiceBus;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BusStop.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CreateSendOnlyBus();
        }

        private void CreateSendOnlyBus()
        {
            var busConfiguration = new BusConfiguration();
            busConfiguration.UseSerialization<XmlSerializer>();

            var ioc = StructuremapMvc.StructureMapDependencyScope.Container;
            busConfiguration.UseContainer<StructureMapBuilder>(customizations => customizations.ExistingContainer(ioc));

            var sendOnlyBus = Bus.CreateSendOnly(busConfiguration);
            sendOnlyBus.OutgoingHeaders["source"] = "BusStop.API";

            ioc.Configure(expression =>
            {
                expression.For<ISendOnlyBus>().Use(sendOnlyBus);
            });
        }
    }
}
