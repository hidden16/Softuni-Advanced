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
        private IWorkshop workshop;
        private int coloredEggs = 0;
        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            bunnies.Add(bunny);
            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
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
            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var currEgg = eggs.FindByName(eggName);
            if (bunnies.Models.All(x => x.Energy < 50))
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            List<IBunny> bunniesToRemove = new List<IBunny>();
            foreach (var bunny in bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy))
            {
                workshop.Color(currEgg, bunny);
                if (bunny.Energy <= 0)
                {
                    bunniesToRemove.Add(bunny);
                }
            }
            foreach (var bunny in bunniesToRemove)
            {
                bunnies.Remove(bunny);
            }
            if (currEgg.IsDone())
            {
                coloredEggs++;
                return String.Format(OutputMessages.EggIsDone, currEgg.Name);
            }
            else
            {
                return String.Format(OutputMessages.EggIsNotDone, currEgg.Name);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{coloredEggs} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                int notFinishedDyes = bunny.Dyes.Where(x => !x.IsFinished()).Count();
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {notFinishedDyes} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
