namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void Test_If_Constructor_Returns_Correct_Values()
        {
            Aquarium aquarium = new Aquarium("Vayne", 15);
            Assert.AreEqual("Vayne", aquarium.Name);
            Assert.AreEqual(15, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_If_Constructor_Recieves_Null_Or_Empty_String_Should_Throw_ArgumentNullException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 15);
            });
        }
        [Test]
        public void Test_If_Constructor_Recieves_Capacity_Less_Than_Zero_Should_Throw_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Peshkata", -5);
            });
        }
        [Test]
        public void Test_Add_If_Fish_Count_Equals_Capacity_Should_Throw_InvalidOperationException()
        {
            Aquarium aquarium = new Aquarium("Peshkata", 0);
            Fish fish = new Fish("Just fish");
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
            });
        }
        [Test]
        public void Test_Add_If_Adds_Correctly_Count_Should_Increase()
        {
            Aquarium aquarium = new Aquarium("Peshkata", 5);
            Fish fish = new Fish("Just fish");
            aquarium.Add(fish);
            Assert.AreEqual(1, aquarium.Count);
        }
        [Test]
        public void Test_Remove_If_Recieves_Invalid_Name_Should_Throw_InvalidOperationException()
        {
            Aquarium aquarium = new Aquarium("Peshkata", 5);
            Fish fish = new Fish("Just fish");
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("JORKATA");
            });
        }
        [Test]
        public void Test_Remove_If_Removes_Correctly_Count_Should_Decrease()
        {
            Aquarium aquarium = new Aquarium("Peshkata", 5);
            Fish fish = new Fish("Just fish");
            aquarium.Add(fish);
            Fish fish2 = new Fish("Another fish");
            aquarium.Add(fish2);
            Fish fish3 = new Fish("Giga chad fish");
            aquarium.Add(fish3);
            aquarium.RemoveFish("Just fish");
            Assert.AreEqual(2, aquarium.Count);
        }
        [Test]
        public void Test_SellFish_If_Recieves_Invalid_Name_Should_Throw_InvalidOperationException()
        {
            Aquarium aquarium = new Aquarium("Peshkata", 5);
            Fish fish = new Fish("I'm fish");
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("ASKJDO");
            });
        }
        [Test]
        public void Test_SellFish_If_Fish_Is_Sold_Available_Should_Be_False()
        {
            Aquarium aquarium = new Aquarium("Peshkata", 5);
            Fish fish = new Fish("Just fish");
            aquarium.Add(fish);
            Fish fish2 = new Fish("Another fish");
            aquarium.Add(fish2);
            Fish fish3 = new Fish("Giga chad fish");
            aquarium.Add(fish3);
            Fish testFish = aquarium.SellFish("Just fish");
            Assert.IsFalse(testFish.Available);
        }
        [Test]
        public void Test_If_Report_Works_Correctly()
        {
            Aquarium aquarium = new Aquarium("AQUABIG", 5);
            Fish fish = new Fish("Just fish");
            aquarium.Add(fish);
            Fish fish2 = new Fish("Another fish");
            aquarium.Add(fish2);
            var checker = aquarium.Report();
            Assert.AreEqual($"Fish available at {aquarium.Name}: Just fish, Another fish", checker);
        }

    }
}
