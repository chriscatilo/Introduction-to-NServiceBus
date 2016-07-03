using BusStop.Billing.Contracts;
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
        private readonly IBus _bus;

        public PlaceHolderHandler(IDocumentSession session, ISayHello say, 
            IBus bus)
        {
            _session = session;
            _say = say;
            _bus = bus;
        }

        public void Handle(PlaceOrder message)
        {
            _session.Store(new Order
                {
                    OrderId = message.OrderId
                });

            _bus.Send(new ChargeCreditCard
            {
                CustomerId = message.CustomerId,
                Amount = 100
            });

            Console.WriteLine("Order received " + message.OrderId);
            Console.WriteLine(_say.Hello);
        }
    }
}
