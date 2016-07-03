using NServiceBus;
using System;

namespace BusStop.Contracts
{
    public class CancelOrder : IMessage
    {
        public Guid OrderId { get; set; }
    }
}