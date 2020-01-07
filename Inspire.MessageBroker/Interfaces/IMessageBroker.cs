namespace Inspire.MessageBroker.Interfaces
{
    public interface IMessageBroker
    {
        void Listen();

        void Subscribe(IConsumer consumer);
    }
}
