using CarSupplier.Application.Messages.CarManufacturer;
using CarSupplier.Domain.Models;
using CarSupplier.Services;
using System;

namespace CarSupplier.Application.MessageConsumers.CarManufacturer
{
    public class FordCarManufacturerConsumer : CarManufacturerMessageConsumer<FordCarSpecificationMessage>
    {
        private readonly ICarService<FordCar> CarService = null;

        public FordCarManufacturerConsumer(ICarService<FordCar> carService)
        {
            this.CarService = carService;
        }

        public override void Consume(FordCarSpecificationMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            message.Describe();
            Console.ResetColor();

            var car = this.CarService.Construct(message);

            car.Show();
        }
    }
}
