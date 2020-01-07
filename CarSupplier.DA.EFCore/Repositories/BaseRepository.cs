using Microsoft.EntityFrameworkCore;

namespace CarSupplier.DA.EFCore.Base
{
    public class BaseRepository<C> where C : DbContext
    {

        public C Context { get; }

        public BaseRepository(C context)
        {
            Context = context;
        }
    }
}
