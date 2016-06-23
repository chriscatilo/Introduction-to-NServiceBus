using BusStop.Contracts;
using NServiceBus;
using Raven.Client;
using System;

namespace BusStop.Backend
{
    public class PlaceHolderHandler : IHandleMessages<PlaceOrder>
    {
        public IDocumentStore Store { get; set; }

        public IDocumentSession Session { get; set; }

        public void Handle(PlaceOrder message)
        {

            Session.Store(new Order
                {
                    OrderId = message.OrderId
                });

            Session.SaveChanges();

            Console.WriteLine("Order received " + message.OrderId);
        }
    }

    public class Order
    {
        public Guid OrderId { get; set; }
    }
}
