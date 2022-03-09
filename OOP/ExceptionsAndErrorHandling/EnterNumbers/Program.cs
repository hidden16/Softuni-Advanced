using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadNumber(1, 100);
            Console.WriteLine(string.Join(", ", numbers));
        }
        public static List<int> ReadNumber(int start, int end)
        {
            var numbers = new List<int>();
            while (numbers.Count != 10)
            {
                try
                {
                    var n = int.Parse(Console.ReadLine());
                    if (n <= start || n >= end)
                    {
                        throw new ArgumentException();
                    }
                    if (numbers.Count == 0)
                    {
                        numbers.Add(n);
                    }
                    else if (n > numbers[numbers.Count - 1])
                    {
                        numbers.Add(n);
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine($"Your number is not in range 1 - 100!");
                    }
                    else
                    {
                        Console.WriteLine($"Your number is not in range {numbers[numbers.Count -1]} - 100!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }
            return numbers;
        }
    }
}
