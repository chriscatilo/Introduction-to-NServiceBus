using NServiceBus;
using System;

namespace BusStop.Sales.InternalMessages
{
    public class CancelOrder : IMessage
    {
        public Guid OrderId { get; set; }
    }
}