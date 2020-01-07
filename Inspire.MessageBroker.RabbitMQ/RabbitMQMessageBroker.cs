using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Inspire.MessageBroker
{
    public class RabbitMQMessageBroker : MessageBroker
    {
        public override void Listen()
        {
            var factory = new RabbitMQ.Client.ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "watership_down", durable: true, exclusive: false, autoDelete: false, arguments: null);
                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var jsonMessage = Encoding.UTF8.GetString(body);

                        try
                        {
                            var messageContext = DesypherMessageType(jsonMessage);

                            Interpret(messageContext);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        }
                    };
                    channel.BasicConsume(queue: "watership_down", autoAck: false, consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
    }
}
