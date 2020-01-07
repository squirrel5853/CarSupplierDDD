using CarSupplier.DA.Caching;
using CarSupplier.DA.Entities;
using CarSupplier.DA.Interfaces;

namespace CarSupplier.DA
{
    public class CarPaintProvider : IProvider<CarPaintEntity, PaintFilter>
    {
        private readonly IRepository<CarPaintEntity, PaintFilter, int> _repository;
        private readonly InMemoryCache<CarPaintEntity> _inMemoryCache;
        public CarPaintProvider(IRepository<CarPaintEntity, PaintFilter, int> repository)
        {
            _repository = repository;
            _inMemoryCache = InMemoryCache<CarPaintEntity>.Instance;
        }

        public CarPaintEntity Get(PaintFilter filter)
        {
            var paint = _inMemoryCache.Get(filter.Name);

            if (paint == null)
            {
                paint = _repository.Get(filter);

                _inMemoryCache.Put(filter.Name, paint);
            }

            return paint;
        }
    }
}
