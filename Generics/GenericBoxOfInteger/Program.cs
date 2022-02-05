using System;

namespace GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Input = input;
                Console.WriteLine(box.ToString());
            }
        }
    }
}
