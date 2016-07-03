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
        public static ISendOnlyBus Bus { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var iocContainer = new StructureMap.Container(expression =>
            {
                expression.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
                });
            });

            StartBus(iocContainer);

            base.OnStartup(e);
        }

        private static void StartBus(Container iocContainer)
        {
            var busConfig = new BusConfiguration();
            
            busConfig.UseContainer<StructureMapBuilder>(cc => cc.ExistingContainer(iocContainer));
            busConfig.UseTransport<MsmqTransport>();
            busConfig.UsePersistence<InMemoryPersistence>();
            busConfig.UseSerialization<XmlSerializer>();

            Bus = NServiceBus.Bus.CreateSendOnly(busConfig);

            Bus.OutgoingHeaders["source"] = "BusStop.Backoffice";
            Bus.OutgoingHeaders["access_token"] = "busstop";
        }
    }
}
