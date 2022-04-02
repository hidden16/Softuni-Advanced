using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitCar car;
        private UnitDriver driver;

        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
            car = new UnitCar("Tesla", 400, 1000);
            driver = new UnitDriver("X", car);
        }

        [Test]
        public void Test_Constructor_If_Sets_Correctly()
        {
            Assert.AreEqual(0, race.Counter);
        }
        [Test]
        public void Test_AddDriver_If_Recieves_Null_UnitDriver_Should_Throw_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(null);
            });
        }
         [Test]
        public void Test_AddDriver_If_Try_To_Add_Same_Driver_Twice_Should_Throw_InvalidOperationException()
        {
            race.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver);
            });
        }
         [Test]
        public void Test_AddDriver_If_Added_Correctly_Count_Should_Increase()
        {
            race.AddDriver(driver);
            Assert.AreEqual(1, race.Counter);
        }
         [Test]
        public void Test_AddDriver_If_Returns_Correct_String()
        {
            var output = race.AddDriver(driver);
            Assert.AreEqual($"Driver X added in race.", output);
        }
         [Test]
        public void Test_CalculateAverageHorsePower_If_Method_Is_Called_With_Less_Than_2_Drivers_Should_Throw_InvalidOperationException()
        {
            race.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();
            });
        }
        [Test]
        public void Test_CalculateAverageHorsePower_If_Returns_Correct_Value()
        {
            UnitCar car2 = new UnitCar("Audi", 200, 500);
            UnitDriver driver2 = new UnitDriver("A3", car2);
            race.AddDriver(driver);
            race.AddDriver(driver2);
            var output = race.CalculateAverageHorsePower();
            Assert.AreEqual(300, output);
        }

    }
}