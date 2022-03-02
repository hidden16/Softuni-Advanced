using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;
        public Seat(string model, string color)
        {
            this.model = model;
            this.color = color;
        }
        public string Color()
        {
            return color;
        }

        public string Model()
        {
            return model;
        }

        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }
        public override string ToString()
        {
            return $"{Color()} Seat {Model()}";
        }
    }
}
