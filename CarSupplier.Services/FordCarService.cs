using CarSupplier.Application.Messages.CarManufacturer.Interfaces;
using CarSupplier.Domain.Models;
using CarSupplier.Domain.Interfaces;

namespace CarSupplier.Services
{
    public class FordCarService : ICarService<FordCar>
    {
        private readonly IVehicleBuilder<FordCar> VehicleBuilder = null;

        public FordCarService(IVehicleBuilder<FordCar> vehicleBuilder)
        {
            this.VehicleBuilder = vehicleBuilder;
        }

        public FordCar Construct(ICarSpecificationMessage carSpecification)
        {
            this.VehicleBuilder.VehicleManufacturerName = "Ford";

            this.VehicleBuilder.BuildEngine(carSpecification.EngineType);
            this.VehicleBuilder.BuildWheels(carSpecification.WheelType);
            this.VehicleBuilder.BuildDoors(carSpecification.NumberOfDoors);

            this.VehicleBuilder.Paint(carSpecification.PaintType, carSpecification.PaintColour);

            return this.VehicleBuilder.Result;
        }
    }
}
