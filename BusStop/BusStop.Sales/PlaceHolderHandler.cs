using BusStop.Sales.Contracts;
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

            // This publisher looks at storage (ie. raven db) 
            // for a list of subscribers of OrderAccepted messages 
            _bus.Publish(new OrderAccepted
            {
                CustomerId = message.CustomerId,
                OrderId = message.OrderId
            });

            Console.WriteLine("Order received " + message.OrderId);
        }
    }
}
