using CarSupplier.DA;
using CarSupplier.DA.Entities;
using CarSupplier.DA.Interfaces;
using CarSupplier.Domain.Interfaces;
using System;

namespace CarSupplier.Domain.Models
{
    public class FordCarBuilder : CarBuilder<FordCar>
    {
        public FordCarBuilder(
            IProvider<TyreEntity, TyreFilter> tyreProvider, 
            IProvider<WheelEntity, WheelFilter> wheelProvider,
            IProvider<CarEngineEntity, EngineFilter> carEngineProvider, 
            IProvider<CarPaintEntity, PaintFilter> carPaintProvider) 
            : base(tyreProvider, wheelProvider, carEngineProvider, carPaintProvider)
        {
        }

        public override FordCar Result
        {
            get
            {
                return new FordCar(this.Engine);
            }
        }
    }

    public abstract class CarBuilder<T> : IVehicleBuilder<T> where T : ICar
    {
        private readonly IProvider<TyreEntity, TyreFilter> _tyreProvider = null;
        private readonly IProvider<WheelEntity, WheelFilter> _wheelProvider = null;
        private readonly IProvider<CarEngineEntity, EngineFilter> _carEngineProvider = null;
        private readonly IProvider<CarPaintEntity, PaintFilter> _carPaintProvider = null;

        public string VehicleManufacturerName { get; set; }

        public Engine Engine { get; private set; }

        public CarBuilder(
            IProvider<TyreEntity, TyreFilter> tyreProvider,
            IProvider<WheelEntity, WheelFilter> wheelProvider,
            IProvider<CarEngineEntity, EngineFilter> carEngineProvider,
            IProvider<CarPaintEntity, PaintFilter> carPaintProvider)
        {
            _tyreProvider = tyreProvider;
            _wheelProvider = wheelProvider;
            _carEngineProvider = carEngineProvider;
            _carPaintProvider = carPaintProvider;
        }

        public void BuildWheels(string wheelType)
        {
            WheelFilter filter = new WheelFilter(wheelType);

            var wheel = _wheelProvider.Get(filter);

            TyreFilter tyreFilter = new TyreFilter(wheel.ManufacturerName);

            var tyres = _tyreProvider.Get(tyreFilter);
        }

        public void BuildEngine(string engineType)
        {
            EngineFilter filter = new EngineFilter(VehicleManufacturerName);

            var engineEntity = _carEngineProvider.Get(filter);

            this.Engine = new Engine(engineEntity.Manufacturer, engineEntity.ModelNumber, engineEntity.BHP, engineEntity.FuelType);
        }

        public void BuildDoors(int numberOfDoors)
        {
            throw new NotImplementedException();
        }

        public void Paint(string paintType, string paintColour)
        {
            var paint = _carPaintProvider.Get(new PaintFilter() { Name = paintColour, Type = paintType });
        }

        public abstract T Result { get; }
    }
}
