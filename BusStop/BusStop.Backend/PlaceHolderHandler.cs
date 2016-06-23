using BusStop.Contracts;
using NServiceBus;
using NServiceBus.UnitOfWork;
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

    public class Order
    {
        public Guid OrderId { get; set; }
    }

    public class RavenUnitOfWork : IManageUnitsOfWork
    { 
        public IDocumentSession Session { get; set; }

        public void Begin()
        {
        }

        public void End(Exception ex = null)
        {
            if (ex != null) 
                Session.SaveChanges();
        }
    }
}
