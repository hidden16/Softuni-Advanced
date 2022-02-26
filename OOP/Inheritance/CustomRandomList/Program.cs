using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rand = new RandomList();
            rand.Add("1");
            rand.Add("2");
            rand.Add("3");
            rand.Add("4");
            rand.Add("5");

            Console.WriteLine(rand.RandomString());
            Console.WriteLine(rand.RandomString());
            Console.WriteLine(rand.RandomString());
            Console.WriteLine(rand.RandomString());
            Console.WriteLine(rand.RandomString());
        }
    }
}
