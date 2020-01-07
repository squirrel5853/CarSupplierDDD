using CarSupplier.DA.EFCore;
using CarSupplier.DA.EFCore.Base;
using CarSupplier.DA.Entities;
using CarSupplier.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSupplier.DA.Repositories
{
    public class CarEngineRepository : BaseRepository<CarSupplierContext>, IRepository<CarEngineEntity, EngineFilter, Guid>
    {
        public CarEngineRepository(CarSupplierContext carSupplierContext) : base(carSupplierContext)
        {
        }

        public CarEngineEntity GetById(Guid id)
        {
            return Context.CarEngines.FirstOrDefault(x => x.Id == id);
        }

        public CarEngineEntity Get(EngineFilter filter)
        {
            return Context.CarEngines
                .Where(x => x.Manufacturer == filter.ManufacturerName)
                .FirstOrDefault();
        }

        public IEnumerable<CarEngineEntity> GetMany(EngineFilter filter)
        {
            throw new NotImplementedException();
        }

        public void Save(CarEngineEntity item)
        {
            throw new NotImplementedException();
        }
    }
}