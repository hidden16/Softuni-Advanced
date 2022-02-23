using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> genericList = new List<double>();
            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                genericList.Add(input);
            }
            double comparingElements = double.Parse(Console.ReadLine());
            Console.WriteLine(Compare(genericList, comparingElements));
        }
        public static double Compare<T>(List<T> list, T element)
           where T : IComparable<T>
        {
            var counter = 0;
            foreach (var generic in list)
            {
                if (generic.CompareTo(element) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
