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
            while (bunny.Energy > 0 && bunny.Dyes.Any(x => x.IsFinished() == false) && egg.IsDone() == false)
            {
                foreach (var dye in bunny.Dyes.Where(x => x.IsFinished() == false))
                {
                    while (dye.Power > 0)
                    {
                        bunny.Work();
                        dye.Use();
                        egg.GetColored();
                        if (bunny.Energy <= 0 || egg.IsDone())
                        {
                            break;
                        }
                    }
                    if (bunny.Energy <= 0 || egg.IsDone())
                    {
                        break;
                    }
                }
            }
        }
    }
}
