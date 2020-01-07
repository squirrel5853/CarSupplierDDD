using CarSupplier.DA.Interfaces;

namespace CarSupplier.DA
{
    public class TyreFilter : IFilter
    {
        public TyreFilter(string wheelManufacturerName)
        {
            this.WheelManufacturerName = wheelManufacturerName;
        }

        public string WheelManufacturerName { get; set; }
    }
}
