using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public interface IShipGrouper : IBattleship, IVessel, ISubmarine
    {
    }
}
