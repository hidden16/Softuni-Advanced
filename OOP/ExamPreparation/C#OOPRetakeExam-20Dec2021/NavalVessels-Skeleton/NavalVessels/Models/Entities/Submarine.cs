namespace NavalVessels.Models.Entities
{
    using System;
    using Models.Contracts;
    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {
            initialArmorThickness = 200;
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (!SubmergeMode)
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                SubmergeMode = false;
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }
        public override string ToString()
        {
            var key = SubmergeMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {key}";
        }
    }
}
