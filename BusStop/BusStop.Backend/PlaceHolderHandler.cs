using BusStop.Contracts;
using NServiceBus;
using Raven.Client;
using System;

namespace BusStop.Backend
{
    public class PlaceHolderHandler : IHandleMessages<PlaceOrder>
    {
        public IDocumentSession Session { get; set; }

        public void Handle(PlaceOrder message)
        {
            Session.Store(new Order
                {
                    OrderId = message.OrderId
                });

            Console.WriteLine("Order received " + message.OrderId);
        }
    }
}
