using CarSupplier.Application.Messages.CarManufacturer.Interfaces;
using CarSupplier.Domain.Interfaces;

namespace CarSupplier.Services
{
    public interface ICarService<C> where C : ICar
    {
        C Construct(ICarSpecificationMessage carSpecification);
    }
}
