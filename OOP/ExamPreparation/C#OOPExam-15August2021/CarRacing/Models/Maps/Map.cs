using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (racerOne.IsAvailable() == false)
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerTwo.IsAvailable() == false)
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            racerOne.Race();
            racerTwo.Race();
            var racerOneBehaviorMultiplier = 0.0;
            if (racerOne.RacingBehavior == "strict")
            {
                racerOneBehaviorMultiplier = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racerOneBehaviorMultiplier = 1.1;
            }
            var racerOneResults = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneBehaviorMultiplier;

            var racerTwoBehaviorMultiplier = 0.0;
            if (racerTwo.RacingBehavior == "strict")
            {
                racerTwoBehaviorMultiplier = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                racerTwoBehaviorMultiplier = 1.1;
            }
            var racerTwoResults = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoBehaviorMultiplier;

            IRacer winner;
            if (racerOneResults > racerTwoResults)
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }
            return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }
    }
}
