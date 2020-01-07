using CarSupplier.Application.Messages.CarManufacturer.Interfaces;
using Inspire.MessageBroker.Interfaces;

namespace CarSupplier.MessageBroker.CarManufacturer
{
    public interface ICarManufacturerMessageConsumer<M> : IConsumer where M : ICarSpecificationMessage
    {
    }
}
