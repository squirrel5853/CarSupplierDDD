using System;
using System.Collections.Generic;
using System.Text;
using CarSupplier.DA.Entities;

namespace CarSupplier.Domain.Models
{
    public class Engine
    {
        public string Manufacturer { get; private set; }
        public string ModelNumber { get; private set; }
        public int BHP { get; private set; }
        public FuelType FuelType { get; private set; }

        public Engine(string manufacturer, string modelNumber, int bhp, FuelType fuelType)
        {
            Manufacturer = manufacturer;
            ModelNumber = modelNumber;
            BHP = bhp;
            FuelType = fuelType;
        }
    }
}
