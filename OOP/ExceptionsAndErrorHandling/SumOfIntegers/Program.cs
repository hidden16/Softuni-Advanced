using System;
using System.Linq;

namespace SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").ToArray();
            var sum = 0;
            var number = string.Empty;
                foreach (var item in input)
                {
                    try
                    {
                        number = item;
                        sum += int.Parse(number);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"The element '{item}' is in wrong format!");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"The element '{item}' is out of range!");
                    }
                    finally
                    {
                        Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
                    }
                }
                Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
