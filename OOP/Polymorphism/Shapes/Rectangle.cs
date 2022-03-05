using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        double height;
        double width;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double CalculateArea()
        {
           return height * width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * width + 2 * height;
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
