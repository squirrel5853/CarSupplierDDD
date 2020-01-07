namespace CarSupplier.DA.Entities
{
    public class CarPaintEntity : IEntity<int>
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}