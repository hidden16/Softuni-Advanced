using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Swap<T>
    {
        List<T> names = new List<T>();
        public List<T> Names { get { return names; } set { this.names = value; } }
        public void Swapper<T>(int indexOne, int indexTwo)
        {
            var container = Names[indexOne];
            Names[indexOne] = Names[indexTwo];
            Names[indexTwo] = container;
            foreach (var name in Names)
            {
                Console.WriteLine($"System.String: {name}");
            }
        }
    }
}
