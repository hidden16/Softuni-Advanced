using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;
        public Tesla(string model, string color, int battery)
        {
            this.model = model;
            this.color = color; 
            this.battery = battery;
        }
        public int Battery()
        {
            return battery;
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
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            return $"{Color()} Tesla {Model()} with {Battery()} Batteries";
        }
    }
}
