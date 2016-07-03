using BusStop.Billing.InternalMessages;
using BusStop.Sales.InternalMessages;
using NServiceBus;
using Raven.Client;
using System;

namespace BusStop.Sales
{
    public class PlaceHolderHandler : IHandleMessages<PlaceOrder>
    {
        private readonly IDocumentSession _session;
        private readonly IBus _bus;

        public PlaceHolderHandler(IDocumentSession session, IBus bus)
        {
            _session = session;
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
        }
    }
}
