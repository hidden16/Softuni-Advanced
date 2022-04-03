using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        // EXCEPT FOR ADDCOMPUTER AND BUYBEST CHECK IF COMPUTER WITH ID EXISTS
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            //computer valid check
            var currComputer = computers.FirstOrDefault(x=>x.Id == computerId);
            if (currComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComponent currComponent = components.FirstOrDefault(x => x.Id == id);
            if (currComponent != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            if (componentType == "Motherboard")
            {
                currComponent = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                currComponent = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                currComponent = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                currComponent = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                currComponent = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if(componentType == "CentralProcessingUnit")
            {
                currComponent = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            currComputer.AddComponent(currComponent);
            components.Add(currComponent);
            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == id);
            if (computer != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            // valid computer check
            var currComputer = computers.FirstOrDefault(x => x.Id == computerId);
            if (currComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral currPeripheral = null;
            if (peripheralType == "Headset")
            {
                currPeripheral = new Headset(id,manufacturer,model,price,overallPerformance,connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                currPeripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                currPeripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                currPeripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            currComputer.AddPeripheral(currPeripheral);
            peripherals.Add(currPeripheral);

            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            var computersWithHigherPrice = computers.Where(x => x.Price > budget).ToList();
            if (computers.Count == 0 || computersWithHigherPrice.Count == computers.Count)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            var currComputer = computers.OrderByDescending(x => x.OverallPerformance).FirstOrDefault(x => x.Price <= budget);
            computers.Remove(currComputer);
            return currComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            // valid computer check
            var currComputer = computers.FirstOrDefault(x => x.Id == id);
            if (currComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            
            computers.Remove(currComputer);
            return currComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            // valid computer check
            var currComputer = computers.FirstOrDefault(x => x.Id == id);
            if (currComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return currComputer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            // valid computer check
            var currComputer = computers.FirstOrDefault(x => x.Id == computerId);
            if (currComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            currComputer.RemoveComponent(componentType);
            var currComponent = components.Find(x => x.GetType().Name == componentType);
            components.Remove(currComponent);
            return String.Format(SuccessMessages.RemovedComponent, componentType, currComponent.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            // valid computer check
            var currComputer = computers.FirstOrDefault(x => x.Id == computerId);
            if (currComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            currComputer.RemovePeripheral(peripheralType);
            var currPeripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            peripherals.Remove(currPeripheral);
            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, currPeripheral.Id);
        }
    }
}
