using BusStop.Billing.InternalMessages;
using NServiceBus;

namespace BusStop.Billing.CreditCardGateway
{
    public class ChargeCreditCardHandler : IHandleMessages<ChargeCreditCard>
    {
        private readonly ICreditCardService _creditCardService;
        private readonly IBus _bus;

        public ChargeCreditCardHandler(ICreditCardService creditCardService, IBus bus)
        {
            _creditCardService = creditCardService;
            _bus = bus;
        }

        public void Handle(ChargeCreditCard message)
        {
            var receipt = _creditCardService.Charge(message.CustomerId, message.Amount);

            _bus.Reply(new CreditCardCharged
            {
                CustomerId = message.CustomerId, Receipt = receipt
            });

        }
    }
}
