using BusStop.Contracts;
using NServiceBus;
using System;

namespace BusStop.Backend
{
    public class PlaceHolderHandler : IHandleMessages<PlaceOrder>
    {
        public void Handle(PlaceOrder message)
        {
            Console.WriteLine("Order received " + message.OrderId);
        }
    }
}
