﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public abstract int Power { get; }
        public abstract string CastAbility();
    }
}
