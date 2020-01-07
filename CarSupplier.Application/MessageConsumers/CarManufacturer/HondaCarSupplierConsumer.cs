using CarSupplier.Application.Messages.CarManufacturer;
using System;

namespace CarSupplier.Application.MessageConsumers.CarManufacturer
{
    public class HondaCarManufacturerConsumer : CarManufacturerMessageConsumer<HondaCarSpecificationMessage>
    {
        public override void Consume(HondaCarSpecificationMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            message.Describe();
            Console.ResetColor();
        }
    }
}
