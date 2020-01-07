namespace CarSupplier.Domain.Interfaces
{
    public interface IVehicleBuilder
    {
        string VehicleManufacturerName { get; set; }
        void BuildEngine(string engineType);
        void BuildWheels(string wheelType);
        void BuildDoors(int numberOfDoors);
        void Paint(string paintType, string paintColour);
    }

    public interface IVehicleBuilder<V> : IVehicleBuilder where V : IVehicle
    {
        V Result { get; }    
    }
}
