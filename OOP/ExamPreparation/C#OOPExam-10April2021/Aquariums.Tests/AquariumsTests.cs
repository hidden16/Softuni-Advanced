namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_Constructor(string name)
        {
            Aquarium aquarium;

            Assert.Throws<ArgumentNullException>(() =>
            {
                aquarium = new Aquarium(name, 15);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                aquarium = new Aquarium("test", -5);
            });

            aquarium = new Aquarium("Vayne", 14);
            Assert.AreEqual("Vayne", aquarium.Name);
            Assert.AreEqual(14, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        public void Test_Add()
        {
            Aquarium aquarium;
            Fish fish = new Fish("Just a fish");
            Fish fish2 = new Fish("Just a second fish");
            aquarium = new Aquarium("Vayne", 0);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
            });

            aquarium = new Aquarium("Vayne", 5);
            aquarium.Add(fish);
            aquarium.Add(fish2);
            Assert.AreEqual(2, aquarium.Count);
        }
        [Test]
        public void Test_RemoveFish()
        {
            Aquarium aquarium = new Aquarium("Vayne", 5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("DASDSAD");
            });

            Fish fish = new Fish("Just a fish");
            Fish fish2 = new Fish("Just a second fish");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.RemoveFish("Just a fish");
            Assert.AreEqual(1, aquarium.Count);
        }
        [Test]
        public void Test_SellFish()
        {
            Aquarium aquarium = new Aquarium("Vayne", 5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("kkekkwe");
            });

            Fish fish = new Fish("Just a fish");
            Fish fish2 = new Fish("Just a second fish");
            aquarium.Add(fish);
            aquarium.Add(fish2);

            aquarium.SellFish("Just a fish");
            Assert.IsFalse(fish.Available);

            var test = aquarium.SellFish("Just a second fish");
            Assert.AreEqual(fish2, test);
        }
        [Test]
        public void Test_Report()
        {
            //$"Fish available at {this.Name}: {fishNames}";

            Aquarium aquarium = new Aquarium("Vayne", 5);
            Fish fish = new Fish("Just a fish");
            Fish fish2 = new Fish("Just a second fish");
            aquarium.Add(fish);
            aquarium.Add(fish2);

            var test = aquarium.Report();
            Assert.AreEqual($"Fish available at Vayne: Just a fish, Just a second fish", test);
        }
    }
}
