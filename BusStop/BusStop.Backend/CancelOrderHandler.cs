using BusStop.Contracts;
using NServiceBus;
using System;

namespace BusStop.Backend
{
    public class CancelOrderHandler : IHandleMessages<CancelOrder>
    {
        private readonly IBus _bus;

        public CancelOrderHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(CancelOrder message)
        {
            Console.WriteLine("Cancelled order " + message.OrderId);

            _bus.Return(CommandStatus.Success);

            Console.WriteLine("Called back " + _bus.GetMessageHeader(message, "source"));
        }
    }
}
