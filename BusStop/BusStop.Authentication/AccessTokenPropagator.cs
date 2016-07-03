using NServiceBus;
using NServiceBus.MessageMutator;
using NServiceBus.Unicast.Messages;

namespace BusStop.Authentication
{
    public class AccessTokenPropagator : IMutateOutgoingTransportMessages
    {
        private readonly IBus _bus;

        public AccessTokenPropagator(IBus bus)
        {
            _bus = bus;
        }

        public void MutateOutgoing(LogicalMessage logicalMessage, TransportMessage transportMessage)
        {
            const string accessTokenLiteral = "access_token";

            if (_bus.CurrentMessageContext == null || !_bus.CurrentMessageContext.Headers.ContainsKey(accessTokenLiteral))
            {
                return;
            }

            transportMessage.Headers[accessTokenLiteral] = _bus.CurrentMessageContext.Headers[accessTokenLiteral];
        }
    }
}
