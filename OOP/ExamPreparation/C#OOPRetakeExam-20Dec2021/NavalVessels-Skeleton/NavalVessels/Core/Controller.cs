namespace NavalVessels.Core
{
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Models.Entities;
    using NavalVessels.Repositories.Entities;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Controller : IController
    {
        private VesselRepository vessels;
        private ICaptain captain;
        private ICollection<ICaptain> captains;
        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var currCaptain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            if (currCaptain == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            var currVessel = vessels.FindByName(selectedVesselName);
            if (currVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (currVessel.Captain.FullName != "Default")
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            currVessel.Captain = currCaptain;
            currCaptain.AddVessel(currVessel);
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = vessels.FindByName(attackingVesselName);
            if (attackingVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            var defendingVessel = vessels.FindByName(defendingVesselName);
            if (defendingVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            if (attackingVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (defendingVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }
            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();
            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            var currCaptain = captains.FirstOrDefault(x => x.FullName == captainFullName);
            if (currCaptain != null)
            {
                return currCaptain.Report();
            }
            return null;
        }

        public string HireCaptain(string fullName)
        {
            var currCaptain = captains.FirstOrDefault(x => x.FullName == fullName);
            if (currCaptain == null)
            {
                captain = new Captain(fullName);
                captains.Add(captain);
                return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
            }
            return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            // reflection try:
            //Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == vesselType);
            //IVessel instanceVessel = (IVessel)Activator.CreateInstance(type, name, mainWeaponCaliber, speed); 
            IVessel vessel;
            if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }
            var currVessel = vessels.FindByName(name);
            if (currVessel == null)
            {
                vessels.Add(vessel);
            }
            else
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            var currVessel = vessels.FindByName(vesselName);
            if (currVessel != null)
            {
                currVessel.RepairVessel();
                return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
            }
            return String.Format(OutputMessages.VesselNotFound, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var currVessel = vessels.FindByName(vesselName);
            if (currVessel != null)
            {
                if (currVessel is Battleship)
                {
                    ((Battleship)currVessel).ToggleSonarMode();
                    return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                }
                else if (currVessel is Submarine)
                {
                    ((Submarine)currVessel).ToggleSubmergeMode();
                    return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
                }
            }
            return String.Format(OutputMessages.VesselNotFound, vesselName);
        }
        public string VesselReport(string vesselName)
        {
            var currVessel = vessels.FindByName(vesselName);
            if (currVessel != null)
            {
                return currVessel.ToString();
            }
            return null;
        }
    }
}
