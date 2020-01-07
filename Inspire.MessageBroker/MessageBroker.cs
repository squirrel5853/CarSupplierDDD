using Inspire.MessageBroker.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Inspire.MessageBroker
{
    public abstract class MessageBroker : IMessageBroker
    {
        List<IConsumer> consumers = new List<IConsumer>();

        public void Subscribe(IConsumer consumer)
        {
            consumers.Add(consumer);
        }

        public MessageContext DesypherMessageType(string jsonObjectAsString)
        {
            JObject obj = (JObject)JsonConvert.DeserializeObject(jsonObjectAsString);
            string objectType = obj["TypeName"].ToString();

            return new MessageContext()
            {
                MessageContent = jsonObjectAsString,
                MessageTypeName = objectType
            };
        }

        public void Interpret(MessageContext context)
        {
            var messageSubscribers = consumers
                                        .Where(x =>
                                            x.GetType().BaseType.GenericTypeArguments.First().Name == context.MessageTypeName);

            foreach (var messageConsumer in messageSubscribers)
            {
                var message = messageConsumer.Interpret(context.MessageContent);

                if (message != null)
                {
                    messageConsumer.Consume(message);
                }
            }
        }

        public abstract void Listen();
    }
}
