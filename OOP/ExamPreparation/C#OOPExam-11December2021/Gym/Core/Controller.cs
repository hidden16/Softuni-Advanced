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
        private List<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var currGym = gyms.First(x => x.Name == gymName);

            IAthlete athlete;
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                if (currGym is BoxingGym)
                {
                    currGym.AddAthlete(athlete);
                }
                else
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                if (currGym is WeightliftingGym)
                {
                    currGym.AddAthlete(athlete);
                }
                else
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            this.equipment.Add(equipment);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            var currGym = gyms.FirstOrDefault(x=>x.Name == gymName);

            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, currGym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var currGym = gyms.FirstOrDefault(x => x.Name == gymName);

            var currEquipment = equipment.FindByType(equipmentType);
            if (currEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            currGym.AddEquipment(currEquipment);
            equipment.Remove(currEquipment);
            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in gyms)
            {
                sb.AppendLine(item.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var currGym = gyms.FirstOrDefault(x=>x.Name == gymName);

            currGym.Exercise();
            return String.Format(OutputMessages.AthleteExercise, currGym.Athletes.Count);
        }
    }
}
