using CarSupplier.DA.Caching;
using CarSupplier.DA.Entities;
using CarSupplier.DA.Interfaces;
using System;

namespace CarSupplier.DA
{
    public class CarEngineProvider : IProvider<CarEngineEntity, EngineFilter>
    {
        private readonly IRepository<CarEngineEntity, EngineFilter, Guid> _repository;
        private readonly InMemoryCache<CarEngineEntity> _inMemoryCache;
        public CarEngineProvider(IRepository<CarEngineEntity, EngineFilter, Guid> repository)
        {
            _repository = repository;
            _inMemoryCache = InMemoryCache<CarEngineEntity>.Instance;
        }

        public CarEngineEntity Get(EngineFilter filter)
        {
            var engine = _inMemoryCache.Get(filter.ManufacturerName);

            if (engine == null)
            {
                engine = _repository.Get(filter);

                _inMemoryCache.Put(filter.ManufacturerName, engine);
            }

            return engine;
        }
    }
}
