using NServiceBus;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BusStop.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        public static ISendOnlyBus Bus { get; set; }

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
            Bus = NServiceBus.Bus.CreateSendOnly(busConfiguration);

            Bus.OutgoingHeaders["source"] = "BusStop.API";
        }
    }
}
