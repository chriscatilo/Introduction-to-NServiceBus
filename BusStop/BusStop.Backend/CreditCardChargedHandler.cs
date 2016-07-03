using BusStop.Billing.Contracts;
using NServiceBus;
using System;

namespace BusStop.Backend
{
    public class CreditCardChargedHandler : IHandleMessages<CreditCardCharged>
    {
        public void Handle(CreditCardCharged message)
        {
            Console.WriteLine($"Customer {message.CustomerId} charged, receipt: {message.Receipt}");
        }
    }
}