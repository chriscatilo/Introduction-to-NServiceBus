using System;

namespace BusStop.Billing.CreditCardGateway
{
    public class DefaultCreditCardService : ICreditCardService
    {
        public string Charge(Guid customerId, double amount)
        {
            Console.WriteLine($"Customer {customerId} charged with: {amount}");

            return Guid.NewGuid().ToString();
        }
    }
}