using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ITelephone
    {
        public string Call(string number)
        {
            foreach (var character in number)
            {
                if (!char.IsDigit(character))
                {
                    return "Invalid number!";
                }
            }
            return $"Dialing... {number}";
        }
    }
}
