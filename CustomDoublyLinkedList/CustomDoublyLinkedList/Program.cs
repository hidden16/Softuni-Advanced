using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doubly = new DoublyLinkedList();
            doubly.AddFirst(1);
            doubly.AddFirst(2);
            doubly.AddFirst(3);
            Console.WriteLine($"Current state");
            doubly.ForEach(n => Console.WriteLine(n));
            Console.WriteLine($"----------------");
            doubly.AddLast(1);
            doubly.AddLast(2);
            doubly.AddLast(3);
            Console.WriteLine($"Current state");
            doubly.ForEach(n => Console.WriteLine(n));
            Console.WriteLine($"----------------");
            doubly.RemoveFirst();
            Console.WriteLine($"Current state");
            doubly.ForEach(n => Console.WriteLine(n));
            Console.WriteLine($"----------------");
            doubly.RemoveLast();
            Console.WriteLine($"Current state");
            doubly.ForEach(n => Console.WriteLine(n));
            Console.WriteLine($"----------------");

        }
    }
}
