using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

namespace BusStop.Config
{
    public class ErrorQueueOverride : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig
            {
                ErrorQueue = "myerrorQ"
            };
        }
    }
}
