using CarSupplier.Application.Messages.CarManufacturer.Interfaces;
using System;

namespace CarSupplier.Application.Messages.CarManufacturer
{
    public abstract class CarSpecificationMessage : ICarSpecificationMessage
    {
        public string TypeName { get { return this.GetType().Name; } }
        public abstract string ManufacturerName { get; }

        public string EngineType { get; set; }

        public string TyreType { get; set; }

        public string WheelType { get; set; }

        public int NumberOfDoors { get; set; }

        public string PaintColour { get; set; }

        public string PaintType { get; set; }

        public void Describe()
        {
            Console.WriteLine($"You want a {ManufacturerName}");
            Console.WriteLine($"with {NumberOfDoors} doors");
            Console.WriteLine($"that has a {EngineType} engine");
            Console.WriteLine($"with {WheelType} wheels");
            Console.WriteLine($"and {TyreType} tyres");
            Console.WriteLine($"in {PaintType} {PaintColour}");
        }
    }
}
