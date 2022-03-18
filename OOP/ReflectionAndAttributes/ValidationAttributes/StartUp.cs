using System;
using ValidationAttributes.Entities;
using ValidationAttributes.Validators;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "peter",
                 22
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
