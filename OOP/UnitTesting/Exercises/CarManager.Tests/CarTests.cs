namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            car = new Car("VW", "Golf", 6, 100);
        }
        [Test]
        public void Test_If_Constructor_Intializes_Properties_Correctly()
        {
            Assert.AreEqual("VW", car.Make);
            Assert.AreEqual("Golf", car.Model);
            Assert.AreEqual(6, car.FuelConsumption);
            Assert.AreEqual(100, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_If_Make_Gets_Null_Or_Empty_In_Constructor_Should_Throw_ArgumentException(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, "Audi", 12, 100);
            });
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_If_Model_Gets_Null_Or_Empty_In_Constructor_Should_Throw_ArgumentException(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("VW", model, 12, 100);
            });
        }
        [Test]
        [TestCase(-400)]
        [TestCase(-100)]
        [TestCase(0)]
        public void Test_If_FuelConsumption_Gets_Less_Than_Zero_In_Constructor_Should_Throw_ArgumentException(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("VW", "Golf", fuelConsumption, 100);
            });
        }
        [Test]
        [TestCase(-400)]
        [TestCase(-100)]
        [TestCase(0)]
        public void Test_If_FuelCapacity_Gets_Less_Than_Zero_Or_Zero_In_Constructor_Should_Throw_ArgumentException(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("VW", "Golf", 5, fuelCapacity);
            });
        }
        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        [TestCase(-4123)]
        public void Test_If_Refuel_Gets_Less_Than_Zero_Or_Zero_As_An_Input_Should_Throw_ArgumentException(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            });
        }
        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(100)]
        [TestCase(1)]
        public void Test_If_Refuel_Increases_FuelAmount_Correctly(double fuelToRefuel)
        {
            car.Refuel(fuelToRefuel);
            Assert.AreEqual(fuelToRefuel, car.FuelAmount);
        }
        [Test]
        public void Test_If_Refuel_Increases_FuelAmount_More_Than_FuelCapacity_Should_Be_Equal_To_The_Fuel_Capacity()
        {
            car.Refuel(150);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }
        [Test]
        public void Test_If_Drive_FuelNeeded_Is_More_Than_FuelAmount_Should_Throw_InvalidOperationException()
        {
            car.Refuel(1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(100);
            });
        }
        [Test]
        public void Test_If_Drive_Reduces_FuelAmount_Correctly()
        {
            car.Refuel(60);
            car.Drive(40);
            Assert.AreEqual(57.6, car.FuelAmount);
        }
    }
}