using BusStop.Contracts;
using NServiceBus;

namespace BusStop.Backend
{
    public class DefaultChargeCustomerHandler : IHandleMessages<PlaceOrder>
    {
        private readonly ICreditCardService _creditCardService;

        public DefaultChargeCustomerHandler(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        public void Handle(PlaceOrder message)
        {
            var receipt = _creditCardService.Charge(message.CustomerId, 100);

            // todo: store receipt in raven db
        }
    }
}