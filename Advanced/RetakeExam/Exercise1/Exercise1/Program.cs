using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] mealsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] maxCaloriesIntakeInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var mealCalories = new Queue<string>(mealsInput);
            var caloriesIntake = new Stack<int>(maxCaloriesIntakeInput);
            var calories = 0;
            while (mealCalories.Count > 0 && caloriesIntake.Count > 0)
            {
                var food = mealCalories.Peek();
                if (food == "salad")
                {
                    calories = 350;
                }
                else if (food == "soup")
                {
                    calories = 490;
                }
                else if (food == "pasta")
                {
                    calories = 680;
                }
                else if (food == "steak")
                {
                    calories = 790;
                }
                var currCalories = caloriesIntake.Peek();
                if (currCalories > calories)
                {
                    currCalories -= calories;
                    caloriesIntake.Push(caloriesIntake.Pop() - calories);
                    mealCalories.Dequeue();
                }
                else if (currCalories < calories)
                {
                    if (caloriesIntake.Count == 1)
                    {
                        caloriesIntake.Pop();
                        mealCalories.Dequeue();
                        break;
                    }

                    calories -= currCalories;
                    caloriesIntake.Pop();
                    caloriesIntake.Push(caloriesIntake.Pop() - calories);
                    mealCalories.Dequeue();
                    
                }
                else if (currCalories == calories)
                {
                    caloriesIntake.Pop();
                    mealCalories.Dequeue();
                }
            }
            if (mealCalories.Count == 0)
            {
                Console.WriteLine($"John had {mealsInput.Length} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ",caloriesIntake)} calories.");
            }
            if (caloriesIntake.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsInput.Length - mealCalories.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ",mealCalories)}.");
            }
        }
    }
}
