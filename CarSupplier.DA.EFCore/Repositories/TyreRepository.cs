using CarSupplier.DA.EFCore;
using CarSupplier.DA.EFCore.Base;
using CarSupplier.DA.Entities;
using CarSupplier.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSupplier.DA.Repositories
{
    public class TyreRepository : BaseRepository<CarSupplierContext>, IRepository<TyreEntity, TyreFilter, int>
    {
        public TyreRepository(CarSupplierContext carSupplierContext) : base(carSupplierContext)
        {
        }

        public TyreEntity GetById(int id)
        {
            return Context.Tyres.FirstOrDefault(x => x.Id == id);
        }
        
        public TyreEntity Get(TyreFilter filter)
        {
            return Context.Tyres
                .Where(x => x.CarManufacturer == filter.WheelManufacturerName)
                .FirstOrDefault();
        }

        public IEnumerable<TyreEntity> GetMany(TyreFilter filter)
        {
            throw new NotImplementedException();
        }

        public void Save(TyreEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
