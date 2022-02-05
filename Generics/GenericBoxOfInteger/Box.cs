using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    class Box<T>
        where T : struct
    {
        public int Input { get; set; }
        public override string ToString()
        {
            return $"System.Int32: {Input}";
        }
    }
}
