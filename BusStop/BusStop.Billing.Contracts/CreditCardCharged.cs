using NServiceBus;
using System;

namespace BusStop.Billing.Contracts
{
    public class CreditCardCharged : IMessage
    {
        public Guid CustomerId { get; set; }

        public string Receipt { get; set; }    
    }
}