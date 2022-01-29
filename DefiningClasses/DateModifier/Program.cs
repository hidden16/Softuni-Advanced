using System;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            DateModifier date = new DateModifier();
            var date1 = Console.ReadLine();
            var date2 = Console.ReadLine();
            date.DateCalculator(date1, date2);
        }
    }
}
