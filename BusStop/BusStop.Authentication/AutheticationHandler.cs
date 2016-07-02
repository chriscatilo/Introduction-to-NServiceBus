using NServiceBus;
using System;

namespace BusStop.Authentication
{
    public class AutheticationHandler : IHandleMessages<IMessage> // handle all messages
    {
        public IBus Bus { get; set; }

        public void Handle(IMessage message)
        {
            var source = Bus.GetMessageHeader(message, "source");

            var msgId = this.Bus.CurrentMessageContext.Id;

            var token = Bus.GetMessageHeader(message, "access_token");

            if (token != "busstop")
            {
                Console.Write("User not authenticated");

                Bus.DoNotContinueDispatchingCurrentMessageToHandlers(); // stop the pipeline

                return;
            }

            Console.WriteLine($"User Authenticated from {source} for {msgId}");
        }
    }
}
