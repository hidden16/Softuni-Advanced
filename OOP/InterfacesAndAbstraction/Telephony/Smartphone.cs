using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ITelephone
    {
        public string Call(string number)
        {
            foreach (var character in number)
            {
                if (!char.IsDigit(character))
                {
                    return $"Invalid number!";
                }
            }
            return $"Calling... {number}";
        }
        public string Browse(string url)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(url))
            {
                return $"Invalid URL!";
            }
            foreach (var character in url)
            {
                if (char.IsDigit(character))
                {
                    return $"Invalid URL!";
                }
            }
            return $"Browsing: {url}!";
        }
    }
}
