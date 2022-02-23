using System;

namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                box.Input = input;
                Console.WriteLine(box.ToString());
            }
        }
    }
}
