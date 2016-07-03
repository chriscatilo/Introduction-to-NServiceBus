using NServiceBus;
using System;

namespace BusStop.Billing.Contracts
{
    public class ChargeCreditCard : IMessage
    {
        public Guid CustomerId { get; set; }

        public double Amount { get; set; }    
    }
}
