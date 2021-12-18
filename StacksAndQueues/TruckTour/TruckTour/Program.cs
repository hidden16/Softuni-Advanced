using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int[]> pumps = new Queue<int[]>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(input);
            }
            int index = 0;
            while (true)
            {
                int sum = 0;
                foreach (var item in pumps)
                {
                    int pump = item[0];
                    int distance = item[1];
                    sum += pump - distance;
                    if (sum < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        index++;
                        break;
                    }
                }
                if (sum >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}
