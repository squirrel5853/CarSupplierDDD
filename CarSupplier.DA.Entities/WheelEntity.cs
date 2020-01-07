namespace CarSupplier.DA.Entities
{
    public class WheelEntity : IEntity<int>
    {
        public string ManufacturerName { get; set; }
        public int Id { get; set; }
    }
}