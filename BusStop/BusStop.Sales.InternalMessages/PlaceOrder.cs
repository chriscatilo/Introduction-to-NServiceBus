using NServiceBus;
using System;

namespace BusStop.Sales.InternalMessages
{
    public class PlaceOrder : IMessage
    {
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public Guid CustomerId { get; set; }

    }
}