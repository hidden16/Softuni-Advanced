using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        string Model();
        string Color();
        string Start();
        string Stop();
    }
}
