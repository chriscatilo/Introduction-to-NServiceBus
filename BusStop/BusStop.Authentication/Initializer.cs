using NServiceBus;

namespace BusStop.Authentication
{
    public class Initializer : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.RegisterComponents(
                components => components.ConfigureComponent<AccessTokenPropagator>(DependencyLifecycle.InstancePerCall));
        }
    }
}