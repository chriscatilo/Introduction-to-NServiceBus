using BusStop.Billing.InternalMessages;
using NServiceBus;
using System;

namespace BusStop.Billing
{
    public class CreditCardChargedHandler : IHandleMessages<CreditCardCharged>
    {
        public void Handle(CreditCardCharged message)
        {
            Console.WriteLine($"Customer {message.CustomerId} charged, receipt: {message.Receipt}");
        }
    }
}