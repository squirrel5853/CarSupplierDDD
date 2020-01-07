using CarSupplier.Application.Messages.Interfaces;
using Inspire.MessageBroker.Interfaces;
using Newtonsoft.Json;

namespace CarSupplier.Application.MessageConsumers.Base
{
    public abstract class BaseMessageConsumer<T> : IConsumer where T : IMessage
    {
        public abstract void Consume(object message);

        public object Interpret(string messageContent)
        {
            try
            {
                var message = JsonConvert.DeserializeObject<T>(messageContent);

                return message;
            }
            catch
            {
                return default;
            }
        }
    }
}
