using CarSupplier.Application.Messages.Interfaces;

namespace CarSupplier.Application.Messages.CarManufacturer.Interfaces
{
    public interface ICarSpecificationMessage : IMessage
    {
        string ManufacturerName { get; }

        string EngineType { get; set; }

        string TyreType { get; set; }

        string WheelType { get; set; }

        int NumberOfDoors { get; set; }

        string PaintColour { get; set; }

        string PaintType { get; set; }
    }
}
