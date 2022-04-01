using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private decimal bill = 0.0m;
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink;
            if (type == "Tea")
            {
                drink = new Tea(name,portion,brand);
                drinks.Add(drink);
                return String.Format(OutputMessages.DrinkAdded, name, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name,portion,brand);
                drinks.Add(drink);
                return String.Format(OutputMessages.DrinkAdded, name, brand);
            }
            return null;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
                bakedFoods.Add(food);
                return String.Format(OutputMessages.FoodAdded, name, type);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
                bakedFoods.Add(food);
                return String.Format(OutputMessages.FoodAdded, name, type);
            }
            return null;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber,capacity);
                tables.Add(table);
                return String.Format(OutputMessages.TableAdded, tableNumber);
            }
            else if(type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
                tables.Add(table);
                return String.Format(OutputMessages.TableAdded, tableNumber);
            }
            return null;
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in tables.Where(x => !x.IsReserved))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
           
            return String.Format(OutputMessages.TotalIncome, bill);
        }

        public string LeaveTable(int tableNumber)
        {
            var currTable = tables.FirstOrDefault(x=>x.TableNumber == tableNumber);
            var tableBill = currTable.GetBill() + currTable.Price;

            bill += tableBill;
            currTable.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {tableBill:f2}");
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var currTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var currDrink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (currTable == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (currDrink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            currTable.OrderDrink(currDrink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var currTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var currFood = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (currTable == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (currFood == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            currTable.OrderFood(currFood);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity > numberOfPeople);
            if (freeTable == null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            freeTable.Reserve(numberOfPeople);
            return String.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
        }
    }
}
