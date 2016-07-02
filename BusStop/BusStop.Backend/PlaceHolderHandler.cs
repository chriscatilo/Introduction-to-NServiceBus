using BusStop.Contracts;
using NServiceBus;
using Raven.Client;
using System;

namespace BusStop.Backend
{
    public class PlaceHolderHandler : IHandleMessages<PlaceOrder>
    {
        private readonly IDocumentSession _session;
        private readonly ISayHello _say;

        public PlaceHolderHandler(IDocumentSession session, ISayHello say)
        {
            _session = session;
            _say = say;
        }

        public void Handle(PlaceOrder message)
        {
            _session.Store(new Order
                {
                    OrderId = message.OrderId
                });

            Console.WriteLine("Order received " + message.OrderId);
            Console.WriteLine(_say.Hello);
        }
    }
}
