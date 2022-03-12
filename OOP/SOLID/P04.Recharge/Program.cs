namespace P04.Recharge
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<Worker> workers = new List<Worker>();
            Worker input;
            input = new Employee("Darth Vader");
            workers.Add(input);
            foreach (ISleeper item in workers)
            {
                item.Sleep();
            }
            input = new Robot("R2D2", 100);
            foreach (IRechargeable item in workers)
            {
                item.Recharge();
            }
        }
    }
}
