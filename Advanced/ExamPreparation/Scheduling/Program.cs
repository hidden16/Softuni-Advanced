using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasksInput = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var threadsInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> tasks = new Stack<int>(tasksInput);
            Queue<int> threads = new Queue<int>(threadsInput);
            var taskToKill = int.Parse(Console.ReadLine());
            while (true)
            {
                if (tasks.Peek() == taskToKill)
                {
                    tasks.Pop();
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
                    Console.WriteLine(string.Join(" ", threads));
                    return;
                }
                else if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else if (threads.Peek() < tasks.Peek())
                {
                    threads.Dequeue();
                }
            }
        }
    }
}
