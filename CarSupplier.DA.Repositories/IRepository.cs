using CarSupplier.DA.Entities;

namespace CarSupplier.DA.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        T Get(int id);

        void Save(T item);
    }
}
