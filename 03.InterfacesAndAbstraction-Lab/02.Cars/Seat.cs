using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Seat : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }
        public string Start()
        {
            return "Engine start";
        }
        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString() => $"{Color} Seat {Model}{Environment.NewLine}{Start()}{Environment.NewLine}{Stop()}";
    }
}
