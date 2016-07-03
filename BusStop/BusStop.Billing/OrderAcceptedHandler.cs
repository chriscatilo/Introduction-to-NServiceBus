using BusStop.Billing.InternalMessages;
using BusStop.Sales.Contracts;
using NServiceBus;
using System;

namespace BusStop.Billing
{
    class OrderAcceptedHandler : IHandleMessages<OrderAccepted>
    {
        private readonly IBus _bus;

        public OrderAcceptedHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(OrderAccepted message)
        {
            Console.WriteLine($"Order {message.OrderId} from Customer {message.CustomerId} accepted");

            _bus.Send(new ChargeCreditCard
            {
                CustomerId = message.CustomerId,

                Amount = 100
            });
        }
    }
}