using NServiceBus;
using NServiceBus.MessageMutator;
using NServiceBus.Unicast.Messages;
using System.Web;

namespace BusStop.API.Authentication
{
    public class AccessTokenMutator : IMutateOutgoingTransportMessages, INeedInitialization
    {
        public void MutateOutgoing(LogicalMessage logicalMessage, TransportMessage transportMessage)
        {
            var accessTokenLiteral = "access_token";

            var accessToken = HttpContext.Current.Request.Params[accessTokenLiteral];

            transportMessage.Headers[accessTokenLiteral] = accessToken;
        }

        public void Customize(BusConfiguration configuration)
        {
            configuration.RegisterComponents(
                components => components.ConfigureComponent<AccessTokenMutator>(DependencyLifecycle.InstancePerCall));
        }
    }
}