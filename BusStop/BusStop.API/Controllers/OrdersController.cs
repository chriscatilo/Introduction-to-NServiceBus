using BusStop.API.Models;
using BusStop.Sales.InternalMessages;
using NServiceBus;
using System;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace BusStop.API.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly ISayHello _say;
        private readonly ISendOnlyBus _bus;

        public OrdersController(ISayHello say, ISendOnlyBus bus)
        {
            _say = say;
            _bus = bus;
        }

        public Result Get([ModelBinder(Name="access_token")]string accessToken = "")
        {
            var order = new PlaceOrder()
            {
                OrderId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
            };
            
            _bus.Send(order);

            return new Result
            {
                Message = _say.Hello,
                OrderId = order.OrderId 
            };
        }

        public class Result
        {
            public string Message { get; set; }

            public Guid OrderId { get; set; }    
        }
    }
}
