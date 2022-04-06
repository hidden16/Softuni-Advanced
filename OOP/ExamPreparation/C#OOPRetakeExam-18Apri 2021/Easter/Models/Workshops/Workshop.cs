using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            if (bunny.Energy > 0 && bunny.Dyes.Any(x => !x.IsFinished()))
            {
                foreach (var dye in bunny.Dyes.Where(x=>!x.IsFinished()))
                {
                    while (!egg.IsDone() && bunny.Energy > 0 && !dye.IsFinished())
                    {
                        egg.GetColored();
                        bunny.Work();
                        dye.Use();
                    }
                    if (egg.IsDone() || bunny.Energy <= 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
