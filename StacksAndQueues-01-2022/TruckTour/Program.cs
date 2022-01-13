using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(input);
            }
            var index = 0;
            while (true)
            {
                var sum = 0;
                foreach (var item in queue)
                {
                    var pump = item[0];
                    var distance = item[1];
                    sum += pump - distance;
                    if (sum < 0)
                    {
                        queue.Enqueue(queue.Dequeue());
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
