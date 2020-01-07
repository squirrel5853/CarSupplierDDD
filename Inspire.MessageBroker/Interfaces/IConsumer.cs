namespace Inspire.MessageBroker.Interfaces
{
    public interface IConsumer
    {
        object Interpret(string messageContent);
        void Consume(object message);
    }
}