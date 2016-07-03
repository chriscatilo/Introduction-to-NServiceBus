using NServiceBus;

namespace BusStop.Config
{
    public static class MyConventions
    {
        public static BusConfiguration SetupMessageConventions(this BusConfiguration busConfiguration)
        {
            var conventionsBuilder = busConfiguration.Conventions();

            conventionsBuilder.DefiningEventsAs(type => type.Namespace?.EndsWith(".Contracts") == true);

            return busConfiguration;
        }
    }
}
