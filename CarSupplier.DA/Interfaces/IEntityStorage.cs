using CarSupplier.DA.Entities;
using System.Collections.Generic;

namespace CarSupplier.DA.Interfaces
{
    public interface IEntityStorage<T, F> where T : IEntity where F : IFilter
    {
        T Get(F filter);
    }
}
