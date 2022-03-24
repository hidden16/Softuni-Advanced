namespace NavalVessels.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models.Contracts;
    using Utilities.Messages;
    public class Captain : ICaptain
    {
        private string fullName;
        public Captain(string fullName)
        {
            FullName = fullName;
            Vessels = new List<IVessel>();
            CombatExperience = 0;
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels { get; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
            }
            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            if (Vessels.Count > 0)
            {
                foreach (var item in Vessels)
                {
                    sb.AppendLine($"{item.ToString()}");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
