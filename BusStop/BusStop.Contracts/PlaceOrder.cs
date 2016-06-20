using NServiceBus;
using System;

namespace BusStop.Contracts
{
    public class PlaceOrder : IMessage
    {
        public Guid ProduictId { get; set; }

        public Guid CustomerId { get; set; }

    }
}