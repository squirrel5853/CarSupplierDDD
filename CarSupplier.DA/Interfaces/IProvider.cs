using CarSupplier.DA.Entities;

namespace CarSupplier.DA.Interfaces
{
    public interface IProvider<T> where T : IEntity
    { 
    
    }

    public interface IProvider<T, F> : IProvider<T>, IEntityStorage<T, F> where T : IEntity where F : IFilter
    {

    }
}
