using System;
using NServiceBus;

namespace BusStop.Billing.InternalMessages
{
    public class CreditCardCharged : IMessage
    {
        public Guid CustomerId { get; set; }

        public string Receipt { get; set; }    
    }
}