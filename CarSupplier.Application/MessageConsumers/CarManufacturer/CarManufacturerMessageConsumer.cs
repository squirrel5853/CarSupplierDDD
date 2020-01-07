using CarSupplier.Application.MessageConsumers.Base;
using CarSupplier.Application.Messages.CarManufacturer.Interfaces;
using CarSupplier.MessageBroker.CarManufacturer;

namespace CarSupplier.Application.MessageConsumers.CarManufacturer
{
    public abstract class CarManufacturerMessageConsumer<T> : BaseMessageConsumer<T>, ICarManufacturerMessageConsumer<T> where T : ICarSpecificationMessage
    {
        public abstract void Consume(T message);

        public override void Consume(object message)
        {
            this.Consume((T)message);
        }

        public new T Interpret(string messageContent)
        {
            return (T)base.Interpret(messageContent);
        }
    }
}
