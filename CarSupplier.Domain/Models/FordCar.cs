using System;
using System.Collections.Generic;
using CarSupplier.Domain.Interfaces;

namespace CarSupplier.Domain.Models
{
    public class FordCar : ICar
    {
        public FordCar(Engine engine)
        {
            this.Engine = engine;
        }

        public void Paint(Paint paint)
        {
            Colour = paint.Colour;
            Finish = paint.Type;
        }

        public IEnumerable<Wheel> Wheels { get; set; }

        public Engine Engine { get; set; }

        public int NumberOfDoors { get; set; }
        public string Colour { get; private set; }
        public string Finish { get; private set; }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");

        }
    }
}
