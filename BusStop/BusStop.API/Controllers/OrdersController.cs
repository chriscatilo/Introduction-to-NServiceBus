using BusStop.Contracts;
using NServiceBus;
using System;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace BusStop.API.Controllers
{
    public class OrdersController : ApiController
    {
        private ISendOnlyBus _bus;

        public OrdersController()
        {
            _bus = WebApiApplication.Bus;
        }

        public Guid Get([ModelBinder(Name="access_token")]string accessToken = "")
        {
            var order = new PlaceOrder()
            {
                OrderId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
            };
            
            _bus.SetMessageHeader(order, "access_token", accessToken);
            
            _bus.Send(order);

            return order.OrderId;
        }
    }
}
