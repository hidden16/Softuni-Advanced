using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateModifier
{
    class DateModifier
    {
        public void DateCalculator(string date1, string date2)
        {
            var dateOne = date1.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var year = dateOne[0];
            var month = dateOne[1];
            var day = dateOne[2];
            DateTime calendar1 = new DateTime(year, month, day);
            var dateTwo = date2.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var year2 = dateTwo[0];
            var month2 = dateTwo[1];
            var day2 = dateTwo[2];
            DateTime calendar2 = new DateTime(year2, month2, day2);
            var result = calendar2.Subtract(calendar1);
            Console.WriteLine(Math.Abs(result.TotalDays));
        }
    }
}
