using CarSupplier.Domain.Models;
using System.Collections.Generic;

namespace CarSupplier.Domain.Interfaces
{
    public interface ICar : IVehicle
    {
        IEnumerable<Wheel> Wheels { get; }

        Engine Engine { get; }

        int NumberOfDoors { get; }
        string Colour { get; }
        string Finish { get; }

        void Show();
    }
}