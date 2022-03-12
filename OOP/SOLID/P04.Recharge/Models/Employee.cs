namespace P04.Recharge
{
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            Console.WriteLine("Spq po 12 chasa");
        }

        // employee can sleep but cant recharge so it doesnt inherit IRechargeable but ISleeper
        public override string ToString()
        {
            return $"Izmorih se da bachkam";
        }
    }
}
