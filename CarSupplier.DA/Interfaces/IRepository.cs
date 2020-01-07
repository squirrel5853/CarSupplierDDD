using CarSupplier.DA.Entities;
using System.Collections.Generic;

namespace CarSupplier.DA.Interfaces
{
    public interface IRepository<T>
    {
        void Save(T item);
    }

    public interface IRepository<T, F, ID> : 
        IRepository<T>, IEntityStorage<T, F> 
        where T : IEntity<ID> 
        where F : IFilter
    {
        T GetById(ID id);
    }
}
