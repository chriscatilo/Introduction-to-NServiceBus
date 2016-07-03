using System;

namespace BusStop.Backend
{
    public interface ICreditCardService
    {
        string Charge(Guid customerId, double amount);
    }
}