using NServiceBus;
using System;

namespace BusStop.Sales.Contracts
{
    // IEvent - Message must be published

    // ICommand - Message must be sent to a specific receipient 

    public class OrderAccepted : IEvent // Order accepted message should always be published
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
