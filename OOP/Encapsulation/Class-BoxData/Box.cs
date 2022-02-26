using System;
using System.Collections.Generic;
using System.Text;

namespace Class_BoxData
{
    public class Box
    {
        double length;
        double width;
        double height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get { return length; }
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }
                    length = value;
                }
                catch (ArgumentException)
                {

                    Console.WriteLine("Length cannot be zero or negative.");
                    Environment.Exit(0);
                }
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }
                    width = value;
                }
                catch (ArgumentException)
                {

                    Console.WriteLine("Width cannot be zero or negative.");
                    Environment.Exit(0);
                }
            }
        }
        public double Height
        {
            get { return height; }
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }
                    height = value;
                }
                catch (ArgumentException)
                {

                    Console.WriteLine("Height cannot be zero or negative.");
                    Environment.Exit(0);
                }
            }
        }
        public double SurfaceArea()
        {
            return 2 * (length * width) + 2 * (length * height) + 2 * (width * height);
        }
        public double LateralSurfaceArea()
        {
            return 2 * (length * height) + 2 * (width * height);
        }
        public double Volume()
        {
            return length * width * height;
        }
    }
}
