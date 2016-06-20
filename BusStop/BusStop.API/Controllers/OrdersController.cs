using BusStop.Contracts;
using NServiceBus;
using System;
using System.Web.Http;

namespace BusStop.API.Controllers
{
    public class OrdersController : ApiController
    {
        public IBus Bus { get; set; }

        public Guid Get()
        {
            var order = new PlaceOrder()
            {
                OrderId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
            };

            Bus.Send(order);

            return order.OrderId;
        }
    }
}
