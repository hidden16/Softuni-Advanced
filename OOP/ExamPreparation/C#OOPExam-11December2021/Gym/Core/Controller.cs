using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;
        private IAthlete athlete;
        private IEquipment types;
        private IGym gym;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var currGym = gyms.First(x => x.Name == gymName);
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                if (currGym is BoxingGym)
                {
                    currGym.AddAthlete(athlete);
                    return String.Format(OutputMessages.EntityAddedToGym, athleteType, currGym.Name);
                }
                else
                {
                    return String.Format(OutputMessages.InappropriateGym);
                }
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                if (currGym is WeightliftingGym)
                {
                    currGym.AddAthlete(athlete);
                    return String.Format(OutputMessages.EntityAddedToGym, athleteType, currGym.Name);
                }
                else
                {
                    return String.Format(OutputMessages.InappropriateGym);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                types = new BoxingGloves();
                this.equipment.Add(types);
                return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
            }
            else if (equipmentType == "Kettlebell")
            {
                types = new Kettlebell();
                this.equipment.Add(types);
                return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
                gyms.Add(gym);
                return string.Format(OutputMessages.SuccessfullyAdded, gymType);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
                gyms.Add(gym);
                return string.Format(OutputMessages.SuccessfullyAdded, gymType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
        }

        public string EquipmentWeight(string gymName)
        {
            var currGym = gyms.First(x => x.Name == gymName);
            return String.Format(OutputMessages.EquipmentTotalWeight, currGym.Name, currGym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            types = this.equipment.FindByType(equipmentType);
            var currGym = gyms.First(x => x.Name == gymName);
            if (types == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            else
            {
                currGym.AddEquipment(types);
                this.equipment.Remove(types);
                return String.Format(OutputMessages.EntityAddedToGym, equipmentType, currGym.Name);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var currGym = gyms.First(x => x.Name == gymName);
            foreach (var athlete in currGym.Athletes)
            {
                athlete.Exercise();
            }
            return String.Format(OutputMessages.AthleteExercise, currGym.Athletes.Count);
        }
    }
}
