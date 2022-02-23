using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> genericList = new List<string>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                genericList.Add(input);
            }
            string comparingElements = Console.ReadLine();
            Console.WriteLine(Compare(genericList, comparingElements)) ;
        }
        public static int Compare<T>(List<T> list, T element)
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
