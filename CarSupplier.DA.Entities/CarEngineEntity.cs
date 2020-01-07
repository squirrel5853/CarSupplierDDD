using System;

namespace CarSupplier.DA.Entities
{
    public enum FuelType
    { 
        Petrol,
        Diesel,
        Electric
    }

    public class CarEngineEntity : IEntity<Guid>
    {
        public string Manufacturer { get; set; }

        public string ModelNumber { get; set; }

        public int BHP { get; set; }

        public FuelType FuelType { get; set; }

        public Guid Id { get; set; }
    }
}