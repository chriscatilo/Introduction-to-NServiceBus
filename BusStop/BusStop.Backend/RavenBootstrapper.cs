using NServiceBus;
using Raven.Client;
using Raven.Client.Document;

namespace BusStop.Backend
{
    public class RavenBootstrapper : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.RegisterComponents(components => components.ConfigureComponent<IDocumentStore>(() =>
            {
                var store = new DocumentStore
                {
                    Url = "http://localhost:8080",
                    DefaultDatabase = "Default" // default database
                };

                store.Initialize();

                return store;
            }, DependencyLifecycle.SingleInstance));

            configuration.RegisterComponents(components => components.ConfigureComponent<IDocumentSession>((builder) =>
            {
                var documentStore = builder.Build<IDocumentStore>();

                return documentStore.OpenSession();

            }, DependencyLifecycle.InstancePerUnitOfWork));

            configuration.RegisterComponents(components => components.ConfigureComponent<RavenUnitOfWork>(DependencyLifecycle.InstancePerUnitOfWork));
        }
    }
}