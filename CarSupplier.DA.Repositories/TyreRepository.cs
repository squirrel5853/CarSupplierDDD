using CarSupplier.DA.EFCore;
using CarSupplier.DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSupplier.DA.Repositories
{
    class TyreRepository : IRepository<TyreEntity>
    {
        public TyreRepository(CarSupplierContext carSupplierContext)
        {
            Context = carSupplierContext;
        }

        public CarSupplierContext Context { get; }

        public TyreEntity Get(int id)
        {
            return Context.Tyres.FirstOrDefault(x => x.Id == id);
        }

        public void Save(TyreEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
