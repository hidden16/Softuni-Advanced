using NUnit.Framework;
using System;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computer;
        [SetUp]
        public void Setup()
        {
            computer = new ComputerManager();
        }
        [Test]
        public void Test_Property_Computer_If_Contains_Right_Values()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Computer computer2 = new Computer("Acer", "Aspire", 9999);
            this.computer.AddComputer(computer2);
            Computer[] value = this.computer.Computers.ToArray();
            Assert.AreEqual(computer, value[0]);
            Assert.AreEqual(computer2, value[1]);
        }
        [Test]
        public void Test_Constructor_If_Instanciates_Correctly()
        {
            Assert.AreEqual(0, computer.Count);
            Assert.AreEqual(0, computer.Computers.Count);
        }

        [Test]
        public void Test_AddComputer_If_Recieves_Null_Computer_Should_Throw_ArgumentNullException()
        {
            Computer computer = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computer.AddComputer(computer);
            });
        }
        [Test]
        public void Test_AddComputer_If_Recieves_Same_Computer_Should_Throw_ArgumentException()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Assert.Throws<ArgumentException>(() =>
            {
                this.computer.AddComputer(computer);
            });
        }
        [Test]
        public void Test_AddComputer_If_Increases_Count_Correctly()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Assert.AreEqual(1, this.computer.Count);
            Assert.AreEqual(1, this.computer.Computers.Count);
        }
        [Test]
        public void Test_Remove_If_Removes_Correctly()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Computer computer2 = new Computer("Acer", "Aspire", 9999);
            this.computer.AddComputer(computer2);
            this.computer.RemoveComputer("Acer", "Aspire");
            Assert.AreEqual(1, this.computer.Count);
            Assert.AreEqual(1, this.computer.Computers.Count);
        }
        [Test]
        public void Test_Remove_If_Returns_Correct_Value()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Computer computer2 = new Computer("Acer", "Aspire", 9999);
            this.computer.AddComputer(computer2);
            var returned = this.computer.RemoveComputer("Acer", "Aspire");
            Assert.AreEqual(computer2, returned);
        }
        [Test]
        public void Test_RemoveComputer_If_Recieves_Null_Manufacturer_Should_Throw_ArgumentNullException()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computer.RemoveComputer(null, "Predator");
            });
        }
        [Test]
        public void Test_RemoveComputer_If_Recieves_Null_Model_Should_Throw_ArgumentNullException()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computer.RemoveComputer("Acer", null);
            });
        }

        [Test]
        public void Test_GetComputer_If_Recieves_Null_Manufacturer_Should_Throw_ArgumentNullException()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computer.GetComputer(null, "Predator");
            });
        }
        [Test]
        public void Test_GetComputer_If_Recieves_Null_Model_Should_Throw_ArgumentNullException()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computer.GetComputer("Acer", null);
            });
        }

        [Test]
        public void Test_GetComputer_If_Recieves_Computer_That_Doesnt_Exist_Should_Throw_ArgumentException()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Assert.Throws<ArgumentException>(() =>
            {
                this.computer.GetComputer("Aser", "Predator");
            });
        }
        [Test]
        public void Test_GetComputer_If_Returns_Correct_Computer()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            var tester = this.computer.GetComputer("Acer", "Predator");
            Assert.AreEqual(computer, tester);
        }
        [Test]
        public void Test_GetComputersByManufacturer_If_Recieves_Null_Manufacturer()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computer.GetComputersByManufacturer(null);
            });
        }
        [Test]
        public void Test_GetComputersByManufacturer_If_Returns_Correct_Values()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            Computer computer2 = new Computer("Acer", "Aspire", 4500);
            this.computer.AddComputer(computer2);
            var computersReturned = this.computer.GetComputersByManufacturer("Acer").ToList();
            Assert.AreEqual(computer, computersReturned[0]);
            Assert.AreEqual(computer2, computersReturned[1]);
        }
        [Test]
        public void Test_GetComputersByManufacturer_If_Recieves_Non_Existen_Manufacturer_Should_Return_EmptyString()
        {
            Computer computer = new Computer("Acer", "Predator", 9999);
            this.computer.AddComputer(computer);
            
            var computersReturned = this.computer.GetComputersByManufacturer("LG");
            Assert.AreEqual(string.Empty, computersReturned);
        }

    }
}