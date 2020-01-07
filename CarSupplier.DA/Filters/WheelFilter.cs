using CarSupplier.DA.Interfaces;

namespace CarSupplier.DA
{
    public class WheelFilter : IFilter
    {
        public WheelFilter(string manufacturerName)
        {
            this.ManufacturerName = manufacturerName;
        }

        public string ManufacturerName { get; set; }
    }
}
