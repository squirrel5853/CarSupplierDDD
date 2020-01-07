using CarSupplier.DA.EFCore;
using CarSupplier.DA.EFCore.Base;
using CarSupplier.DA.Entities;
using CarSupplier.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSupplier.DA.Repositories
{
    public class WheelRepository : BaseRepository<CarSupplierContext>, IRepository<WheelEntity, WheelFilter, int>
    {
        public WheelRepository(CarSupplierContext carSupplierContext) : base(carSupplierContext)
        {
        }

        public WheelEntity GetById(int id)
        {
            return Context.Wheels.FirstOrDefault(x => x.Id == id);
        }

        public WheelEntity Get(WheelFilter filter)
        {
            return Context.Wheels
                .Where(x => x.ManufacturerName == filter.ManufacturerName)
                .FirstOrDefault();
        }

        public IEnumerable<WheelEntity> GetMany(WheelFilter filter)
        {
            throw new NotImplementedException();
        }

        public void Save(WheelEntity item)
        {
            throw new NotImplementedException();
        }
    }
}