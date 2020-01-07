using CarSupplier.DA.Caching;
using CarSupplier.DA.Entities;

namespace CarSupplier.DA
{
    public class TyreCache : InMemoryCache<TyreEntity>
    {
        protected TyreCache() : base(DEFAULT_MEMORY_EXPIRATION_TIME_IN_SECONDS)
        {
        }
    }
}