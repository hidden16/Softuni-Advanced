namespace NavalVessels.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models.Contracts;
    using Utilities.Messages;
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        protected double initialArmorThickness = 0;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            Captain = new Captain("Default");
            Targets = new List<string>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value;
            }
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }
        public ICollection<string> Targets { get; }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            target.ArmorThickness -= MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            Targets.Add(target.Name);
        }

        public void RepairVessel()
        {
            if (ArmorThickness < initialArmorThickness)
            {
                ArmorThickness = initialArmorThickness;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            if (Targets.Count > 0)
            {
                sb.AppendLine($" *Targets: {string.Join(", ", Targets)}");
            }
            else
            {
                sb.AppendLine($" *Targets: None");
            }
            return sb.ToString().TrimEnd();
        }
    }
}


