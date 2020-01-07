using CarSupplier.DA.Caching;
using CarSupplier.DA.Entities;
using CarSupplier.DA.Interfaces;

namespace CarSupplier.DA
{
    public class WheelProvider : IProvider<WheelEntity, WheelFilter>
    {
        private readonly IRepository<WheelEntity, WheelFilter, int> _repository;
        private readonly InMemoryCache<WheelEntity> _inMemoryCache;
        public WheelProvider(IRepository<WheelEntity, WheelFilter, int> repository)
        {
            _repository = repository;
            _inMemoryCache = InMemoryCache<WheelEntity>.Instance;
        }

        public WheelEntity Get(WheelFilter filter)
        {
            var wheel = _inMemoryCache.Get(filter.ManufacturerName);

            if (wheel == null)
            {
                wheel = _repository.Get(filter);

                _inMemoryCache.Put(filter.ManufacturerName, wheel);
            }

            return wheel;
        }
    }
}
