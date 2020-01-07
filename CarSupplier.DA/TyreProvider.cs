using CarSupplier.DA.Caching;
using CarSupplier.DA.Entities;
using CarSupplier.DA.Interfaces;

namespace CarSupplier.DA
{
    public class TyreProvider : IProvider<TyreEntity, TyreFilter>
    {
        private readonly IRepository<TyreEntity, TyreFilter, int> _repository;
        private readonly InMemoryCache<TyreEntity> _inMemoryCache;
        public TyreProvider(IRepository<TyreEntity, TyreFilter, int> repository)
        {
            _repository = repository;
            _inMemoryCache = InMemoryCache<TyreEntity>.Instance;
        }

        public TyreEntity Get(TyreFilter filter)
        {
            var tyre = _inMemoryCache.Get(filter.WheelManufacturerName);

            if (tyre == null)
            {
                tyre = _repository.Get(filter);

                _inMemoryCache.Put(filter.WheelManufacturerName, tyre);
            }

            return tyre;
        }
    }
}
