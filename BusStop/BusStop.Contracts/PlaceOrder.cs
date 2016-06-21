using NServiceBus;
using System;

namespace BusStop.Contracts
{
    [TimeToBeReceived("00:00:10")]
    public class PlaceOrder : IMessage
    {
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public Guid CustomerId { get; set; }

    }
}