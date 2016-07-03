using System;

namespace BusStop.Billing.CreditCardGateway
{
    public interface ICreditCardService
    {
        string Charge(Guid customerId, double amount);
    }
}