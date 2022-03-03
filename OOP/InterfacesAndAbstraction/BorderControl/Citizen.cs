using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public abstract class Citizen
    {
        public abstract string Id { get; set; }
        public abstract bool FakeId(string Id, string checker);
    }
}
