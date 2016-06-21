using BusStop.Contracts;
using System;
using System.Web.Http;

namespace BusStop.API.Controllers
{
    public class OrdersController : ApiController
    {
        public Guid Get()
        {
            var order = new PlaceOrder()
            {
                OrderId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
            };

            WebApiApplication.Bus.Send(order);

            return order.OrderId;
        }
    }
}
