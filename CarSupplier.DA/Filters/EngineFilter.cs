using CarSupplier.DA.Interfaces;

namespace CarSupplier.DA
{
    public class EngineFilter : IFilter
    {
        public EngineFilter(string manufacturerName)
        {
            this.ManufacturerName = manufacturerName;
        }

        public string ManufacturerName { get; set; }
    }
}
