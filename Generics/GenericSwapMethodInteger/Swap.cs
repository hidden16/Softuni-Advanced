using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    public class Swap<T>
    {
        List<T> swapper = new List<T>();
        public List<T> Swapper { get { return swapper; } set { this.swapper = value; } }
        public void IndexSwapper<T>(int indexOne, int indexTwo)
        {
            var container = Swapper[indexOne];
            Swapper[indexOne] = Swapper[indexTwo];
            Swapper[indexTwo] = container;
            foreach (var item in Swapper)
            {
                Console.WriteLine($"System.Int32: {item}");
            }
        }
    }
}
