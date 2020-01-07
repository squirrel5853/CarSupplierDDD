using Apache.NMS;
using System;

namespace Inspire.MessageBroker
{
    public class ActiveMQMessageBroker : MessageBroker
    {
        public override void Listen()
        {
            string queueName = "TextQueue";

            string brokerUri = $"activemq:tcp://localhost:61616";  // Default port
            NMSConnectionFactory factory = new NMSConnectionFactory(brokerUri);

            using (Apache.NMS.IConnection connection = factory.CreateConnection())
            {
                connection.Start();
                using (ISession session = connection.CreateSession(AcknowledgementMode.IndividualAcknowledge))
                using (IDestination dest = session.GetQueue(queueName))
                using (IMessageConsumer consumer = session.CreateConsumer(dest))
                {
                    IMessage msg = consumer.Receive();

                    try
                    {
                        if ((msg is ITextMessage) == false)
                        {
                            throw new Exception("Unexpected message type: " + msg.GetType().Name);
                        }

                        ITextMessage txtMsg = msg as ITextMessage;
                        string jsonMessage = txtMsg.Text;

                        var messageContext = DesypherMessageType(jsonMessage);

                        Interpret(messageContext);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        msg.Acknowledge();
                    }

                }
            }
        }
    }
}
