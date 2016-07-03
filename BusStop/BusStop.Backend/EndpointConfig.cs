using BusStop.Config;
using NServiceBus.Persistence;

namespace BusStop.Backend
{
    using BusStop.Authentication;
    using NServiceBus;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server,
		ISpecifyMessageHandlerOrdering // message processing pipeline ordering
	{
		public void Customize(BusConfiguration configuration)
		{
			// NServiceBus provides the following durable storage options
			// To use RavenDB, install-package NServiceBus.RavenDB and then use configuration.UsePersistence<RavenDBPersistence>();
			// To use SQLServer, install-package NServiceBus.NHibernate and then use configuration.UsePersistence<NHibernatePersistence>();
			
			// If you don't need a durable storage you can also use, configuration.UsePersistence<InMemoryPersistence>();
			// more details on persistence can be found here: http://docs.particular.net/nservicebus/persistence-in-nservicebus
			
			//Also note that you can mix and match storages to fit you specific needs. 
			//http://docs.particular.net/nservicebus/persistence-order
            
            // This now stores subcribers durably to raven db
			configuration.UsePersistence<RavenDBPersistence>()
                .DoNotSetupDatabasePermissions();

		    configuration.SetupMessageConventions();

			ConfigureIoC(configuration);
		}

		private void ConfigureIoC(BusConfiguration busConfiguration)
		{
			var container = new StructureMap.Container(expression =>
			{
				expression.AddRegistry<DefaultRegistry>();
			});

			busConfiguration.UseContainer<StructureMapBuilder>(customizations => customizations.ExistingContainer(container));
		}

		// message processing pipeline ordering
		public void SpecifyOrder(NServiceBus.Order order)
		{
			order.SpecifyFirst<First<AuthenticationHandler>>();
		}
	}
}
