using System;

namespace BusStop.Sales.Contracts
{
    // IEvent removed replaced with convensions
    public class OrderAccepted
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
