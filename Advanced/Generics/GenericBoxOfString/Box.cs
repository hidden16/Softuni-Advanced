using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        public T Input { get; set; }
        public override string ToString()
        {
            return $"System.String: {Input}";
        }
    }
}
