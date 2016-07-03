using BusStop.Sales.Contracts;
using NServiceBus;
using System;

namespace BusStop.Billing
{
    class OrderAcceptedHandler : IHandleMessages<OrderAccepted>
    {
        public void Handle(OrderAccepted message)
        {
            Console.WriteLine($"Order {message.OrderId} from Customer {message.CustomerId} accepted");
        }
    }
}