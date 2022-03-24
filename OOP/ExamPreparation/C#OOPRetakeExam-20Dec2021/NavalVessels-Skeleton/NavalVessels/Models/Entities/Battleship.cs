namespace NavalVessels.Models.Entities
{
    using System;
    using Models.Contracts;
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
            initialArmorThickness = 300;
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (!SonarMode)
            {
                SonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                SonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }
        public override string ToString()
        {
            var key = SonarMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {key}";
        }
    }
}
