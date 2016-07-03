using NServiceBus;
using StructureMap;
using StructureMap.Graph;
using System.Windows;

namespace BusStop.BackOffice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Container = new StructureMap.Container(expression =>
            {
                expression.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
                });
            });

            StartBus();

            base.OnStartup(e);
        }

        private static void StartBus()
        {
            var busConfig = new BusConfiguration();
            
            busConfig.UseContainer<StructureMapBuilder>(cc => cc.ExistingContainer(Container));
            busConfig.UseTransport<MsmqTransport>();
            busConfig.UsePersistence<InMemoryPersistence>();
            busConfig.UseSerialization<XmlSerializer>();
            

            var bus = NServiceBus.Bus.Create(busConfig);

            bus.OutgoingHeaders["source"] = "BusStop.Backoffice";
            bus.OutgoingHeaders["access_token"] = "busstop";

            Container.Configure(expression => expression.For<IBus>().Use(bus));

            bus.Start();
        }
    }
}
