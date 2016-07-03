using NServiceBus;
using System;

namespace BusStop.Sales.Contracts
{
    public class OrderAccepted : IMessage
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
