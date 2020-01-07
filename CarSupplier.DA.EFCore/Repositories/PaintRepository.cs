using CarSupplier.DA.EFCore;
using CarSupplier.DA.EFCore.Base;
using CarSupplier.DA.Entities;
using CarSupplier.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSupplier.DA.Repositories
{
    public class PaintRepository : BaseRepository<CarSupplierContext>, IRepository<CarPaintEntity, PaintFilter, int>
    {
        public PaintRepository(CarSupplierContext carSupplierContext) : base(carSupplierContext)
        {
        }

        public CarPaintEntity GetById(int id)
        {
            return Context.Paints.FirstOrDefault(x => x.Id == id);
        }

        public CarPaintEntity Get(PaintFilter filter)
        {
            return Context.Paints
                .Where(x => x.Name == filter.Name)
                .FirstOrDefault();
        }

        public IEnumerable<CarPaintEntity> GetMany(PaintFilter filter)
        {
            throw new NotImplementedException();
        }

        public void Save(CarPaintEntity item)
        {
            throw new NotImplementedException();
        }
    }
}