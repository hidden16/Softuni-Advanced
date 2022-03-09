using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Entities.Animals
{
    public static class ExceptionHelper
    {
        public static void PrintException(string animalName, string foodName)
        {
            Console.WriteLine($"{animalName} does not eat {foodName}!");
        }
    }
}
