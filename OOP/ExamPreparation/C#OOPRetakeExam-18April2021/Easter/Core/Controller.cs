using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
                bunnies.Add(bunny);
                return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
                bunnies.Add(bunny);
                return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            var currBunny = bunnies.FindByName(bunnyName);
            if (currBunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            currBunny.AddDye(dye);
            return String.Format(OutputMessages.DyeAdded, power, currBunny.Name);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.FindByName(eggName);
            if (bunnies.Models.All(x=>x.Energy < 50))
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            IWorkshop workshop = new Workshop();
            List<IBunny> bunniesToRemove = new List<IBunny>();
            foreach (var bunny in bunnies.Models.Where(x=>x.Energy >= 50).OrderByDescending(x=>x.Energy))
            {
                workshop.Color(egg, bunny);
                if (bunny.Energy == 0)
                {
                    bunniesToRemove.Add(bunny);
                }
            }
            foreach (var item in bunniesToRemove)
            {
                bunnies.Remove(item);
            }
            if (egg.IsDone())
            {
                return String.Format(OutputMessages.EggIsDone, egg.Name);
            }
            else
            {
                return String.Format(OutputMessages.EggIsNotDone, egg.Name);
            }
        }

        public string Report()
        {
            List<IEgg> coloredEggs = eggs.Models.Where(x => x.IsDone() == true).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{coloredEggs.Count} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                var notFinishedDyes = bunny.Dyes.Where(x => x.IsFinished() == false).ToList();
                sb.AppendLine($"Dyes: {notFinishedDyes.Count} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
