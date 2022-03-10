using System;
using System.Linq;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var counter = 0;
            while (counter != 3)
            {
                try
                {
                    var commands = Console.ReadLine().Split();
                    var index = int.Parse(commands[1]);
                    if (commands[0] == "Replace")
                    {
                        var element = int.Parse(commands[2]);
                        numbers[index] = element;
                    }
                    else if (commands[0] == "Show")
                    {
                        Console.WriteLine(numbers[index]);
                    }
                    else if (commands[0] == "Print")
                    {
                        var endIndex = int.Parse(commands[2]);
                        if (index < 0 || endIndex > numbers.Length - 1)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        for (int i = index; i <= endIndex; i++)
                        {
                            if (i < endIndex)
                            {
                                Console.Write(numbers[i] + ", ");

                            }
                            else
                            {
                                Console.Write(numbers[i]);
                            }
                        }
                        Console.WriteLine();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    counter++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    counter++;
                }
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
