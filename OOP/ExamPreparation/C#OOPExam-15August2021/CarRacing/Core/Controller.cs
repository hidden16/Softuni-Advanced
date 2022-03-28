using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racer;
        private IMap map;
        public Controller()
        {
            cars = new CarRepository();
            racer = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
                cars.Add(car);
                return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
                cars.Add(car);
                return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer;
            ICar car = cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
                this.racer.Add(racer);
                return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
                this.racer.Add(racer);
                return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = racer.FindBy(racerOneUsername);
            if (racerOne == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            var racerTwo = racer.FindBy(racerTwoUsername);
            if (racerTwo == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            var outputMsg = map.StartRace(racerOne, racerTwo);
            return outputMsg;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var racer in racer.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
