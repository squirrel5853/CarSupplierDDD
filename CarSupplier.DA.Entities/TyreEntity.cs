namespace CarSupplier.DA.Entities
{
    public class TyreEntity : IEntity<int>
    {
        public int Id { get; set; }

        public int Width { get; set; }

        public int Ratio { get; set; }

        public int RimSize { get; set; }

        public bool RunFlat { get; set; }
        public string CarManufacturer { get; set; }
        public string Name { get; set; }
    }
}